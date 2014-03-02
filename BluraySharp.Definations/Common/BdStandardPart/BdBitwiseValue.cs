using BluraySharp.Common.BdPartFramework;
using System;
using System.Text;

namespace BluraySharp.Common.BdStandardPart
{
	/// <summary>
	/// 8-bit-sized bitwise value
	/// </summary>
	internal class BdBitwise8 : BdBitwiseValue<System.Byte>
	{
		[BdUIntField(BdIntSize.U8)]
		public override ulong Value { get; set; }

		/// <summary>
		/// Ctor
		/// </summary>
		public BdBitwise8(): this(0) { }
		/// <summary>
		/// Ctor with initial value
		/// </summary>
		/// <param name="value">Initial value</param>
		public BdBitwise8(System.Byte value) : base(value) { }
	}

	/// <summary>
	/// 16-bit-sized bitwise value
	/// </summary>
	internal class BdBitwise16 : BdBitwiseValue<System.UInt16>
	{
		[BdUIntField(BdIntSize.U16)]
		public override ulong Value { get; set; }

		public BdBitwise16() : this(0) { }
		public BdBitwise16(System.UInt16 value) : base(value) { }
	}

	/// <summary>
	/// 32-bit-sized bitwise value
	/// </summary>
	internal class BdBitwise32 : BdBitwiseValue<System.UInt32>
	{
		[BdUIntField(BdIntSize.U32)]
		public override ulong Value { get; set; }

		public BdBitwise32(): this(0) { }
		public BdBitwise32(System.UInt32 value) : base(value) { }
	}

	/// <summary>
	/// 64-bit-sized bitwise value
	/// </summary>
	internal class BdBitwise64 : BdBitwiseValue<System.UInt64>
	{
		[BdUIntField(BdIntSize.U64)]
		public override ulong Value { get; set; }

		public BdBitwise64(): this(0) { }
		public BdBitwise64(System.UInt64 value) : base(value) { }
	}

	internal abstract class BdBitwiseValue<T> : BdPart
		where T : struct, IConvertible
	{
		public BdBitwiseValue(T value)
		{
			this.Value = Convert.ToUInt64(value);
		}

		public abstract ulong Value
		{
			get;
			set;
		}

		protected byte ValueSize
		{
			get
			{
				return (byte) System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
			}
		}

		public T this[byte index, byte length]
		{
			get
			{
				this.VerifyIndexRange(index, length);

				ulong tValue = ~(0xFFFFFFFFFFFFFFFF << length);
				tValue &= (this.Value >> index);

				return (T) tValue.ToUInt((BdIntSize) this.ValueSize);
			}
			set
			{
				this.VerifyIndexRange(index, length);

				ulong tValue1 = ~(0xFFFFFFFFFFFFFFFF << length);
				ulong tValue2 = ~(tValue1 << index);

				tValue2 &= this.Value;
				tValue1 &= Convert.ToUInt64(value);

				this.Value = tValue2 | (tValue1 << index);
			}
		}

		private void VerifyIndexRange(byte index, byte length)
		{
			BdBitwiseValue<T>.VerifyIndexRange(this.ValueSize, index, length);
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

		public override string ToString()
		{
			int tStrLen = this.ValueSize;	//count of splitters
			int tLen = (tStrLen <<3);	//count of bits
			tStrLen += tLen; //length of total

			StringBuilder tString = new StringBuilder(tStrLen, tStrLen);
			ulong tMask = this.Value;

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
