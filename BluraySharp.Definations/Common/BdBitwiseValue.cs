using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	/// <summary>
	/// 8-bit-sized bitwise value
	/// </summary>
	internal class BdBitwise8 : BdBitwiseValue<System.Byte>
	{
		/// <summary>
		/// Ctor
		/// </summary>
		public BdBitwise8(): this(0) { }
		/// <summary>
		/// Ctor will initial value
		/// </summary>
		/// <param name="value">Initial value</param>
		public BdBitwise8(System.Byte value) : base(value) { }
	}

	/// <summary>
	/// 16-bit-sized bitwise value
	/// </summary>
	internal class BdBitwise16 : BdBitwiseValue<System.UInt16>
	{
		public BdBitwise16() : this(0) { }
		public BdBitwise16(System.UInt16 value) : base(value) { }
	}

	/// <summary>
	/// 32-bit-sized bitwise value
	/// </summary>
	internal class BdBitwise32 : BdBitwiseValue<System.UInt32>
	{
		public BdBitwise32(): this(0) { }
		public BdBitwise32(System.UInt32 value) : base(value) { }
	}

	/// <summary>
	/// 64-bit-sized bitwise value
	/// </summary>
	internal class BdBitwise64 : BdBitwiseValue<System.UInt64>
	{
		public BdBitwise64(): this(0) { }
		public BdBitwise64(System.UInt64 value) : base(value) { }
	}

	internal abstract class BdBitwiseValue
	{
		public delegate object Reader(IBdRawIoContext context);
		public delegate void Writer(IBdRawIoContext context, object value);
		public delegate ulong Importer(object value);
		public delegate object Exporter(ulong value);

		public struct BdBitwiseValueType
		{
			public byte Size;
			public Reader Reader;
			public Writer Writer;
			public Importer Importer;
			public Exporter Exporter;
		}

		private static Dictionary<string, BdBitwiseValueType> _ValueTypes = new Dictionary<string, BdBitwiseValueType>()
		{
			{
				"System.Byte", 
				new BdBitwiseValueType()
				{
					Size = 1,
					Reader = (c => c.DeserializeByte()),
					Writer = ((c, v)=> c.Serialize((byte) v)),
					Importer = (v => (ulong) ((byte)v)),
					Exporter = (v => (byte) v)
				}
			},

			{
				"System.UInt16",
				new BdBitwiseValueType()
				{
					Size = 2,
					Reader = (c => c.DeserializeUInt16()),
					Writer = ((c, v)=> c.Serialize((ushort) v)),
					Importer = (v => (ulong) ((ushort)v)),
					Exporter = (v => (ushort) v)
				}
			},

			{
				"System.UInt32",
				new BdBitwiseValueType()
				{
					Size = 4,
					Reader = (c => c.DeserializeUInt32()),
					Writer = ((c, v)=> c.Serialize((uint) v)),
					Importer = (v => (ulong) ((uint)v)),
					Exporter = (v => (uint) v)
				}
			},

			{
				"System.UInt64",
				new BdBitwiseValueType()
				{
					Size = 8,
					Reader = (c => c.DeserializeUInt64()),
					Writer = ((c, v)=> c.Serialize((ulong) v)),
					Importer = (v => (ulong) v),
					Exporter = (v => v)
				}
			},
		};

		public BdBitwiseValue(string baseType)
		{
			ValueTypeDesc = _ValueTypes[baseType];
		}

		public BdBitwiseValueType ValueTypeDesc { get; private set; }
	}

	internal abstract class BdBitwiseValue<T> : BdBitwiseValue, IBdObject
	{
		public BdBitwiseValue(T value) :
			base(typeof(T).FullName)
		{
			_Value = this.ValueTypeDesc.Importer(value);
		}

		private ulong _Value;

		public T this[byte index, byte length]
		{
			get
			{
				this.VerifyIndexRange(index, length);

				ulong tValue = ~(0xFFFFFFFFFFFFFFFF << length);
				tValue &= (_Value >> index);

				return (T)this.ValueTypeDesc.Exporter(tValue);
			}
			set
			{
				this.VerifyIndexRange(index, length);

				ulong tValue1 = ~(0xFFFFFFFFFFFFFFFF << length);
				ulong tValue2 = ~(tValue1 << index);

				tValue2 &= _Value;
				tValue1 &= this.ValueTypeDesc.Importer(value);

				_Value = tValue2 | (tValue1 << index);
			}
		}

		private void VerifyIndexRange(byte index, byte length)
		{
			BdBitwiseValue<T>.VerifyIndexRange(this.ValueTypeDesc.Size, index, length);
		}

		private static void VerifyIndexRange(byte size, byte index, byte length)
		{
			size <<= 3;

			if (index > size)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			else if (index + length > size)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			else if (length < 1)
			{
				throw new ArgumentException("length");
			}
		}

		public long SerializeTo(IBdRawIoContext context)
		{
			object tValue = this.ValueTypeDesc.Exporter(_Value);
			this.ValueTypeDesc.Writer(context, tValue);

			return context.Offset;
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			object tValue = this.ValueTypeDesc.Reader(context);
			_Value = this.ValueTypeDesc.Importer(tValue);

			return context.Offset;
		}

		public long RawLength
		{
			get
			{
				return this.ValueTypeDesc.Size;
			}
		}

		public override string ToString()
		{
			int tStrLen = this.ValueTypeDesc.Size;	//count of splitters
			int tLen = (tStrLen <<3);	//count of bits
			tStrLen += tLen; //length of total

			StringBuilder tString = new StringBuilder(tStrLen, tStrLen);
			ulong tMask = _Value;

			for (int i = tLen - 1; i >= 0; --i)
			{
				tString.Append((tMask & 0x8000000000000000u) == 0 ? '0' : '1');
				if ((i & 0x07) == 0)
				{
					tString.Append('-');
				}

				tMask <<= 1;
			}
			tString[tStrLen - 1] = '\0';

			return tString.ToString();
		}
	}
}
