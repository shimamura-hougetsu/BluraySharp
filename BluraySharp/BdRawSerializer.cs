﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using LibElfin.WinApi.MemoryBlock;
using LibElfin.WinApi;
using System.Runtime.InteropServices;

namespace BluraySharp
{
	public class BdRawSerializeContext
	{
		public BdRawSerializeContext(MemBlock memory)
		{
			_Scope = new BdRawSerializeScope(memory, 0);
		}

		public long Offset
		{
			get
			{
				return _Scope.Offset.ToInt64();
			}
			set
			{
				_Scope.Offset = value;
			}
		}

		public long Length
		{
			get
			{
				return _Scope.Buffer.Length.ToInt64();
			}
		}

		#region Scope

		private BdRawSerializeScope _Scope;

		private readonly Stack<BdRawSerializeScope> _ScopeStack = new Stack<BdRawSerializeScope>();

		public void EnterScope()
		{
			this.EnterScope(this.Length);
		}

		public void EnterScope(long length)
		{
			MemOffset tLen = _Scope.Buffer.Length - _Scope.Offset;
			if(length < tLen)
			{
				tLen = length;
			}

			_ScopeStack.Push(_Scope);
			_Scope = new BdRawSerializeScope(
					new MemBlockRef(_Scope.Buffer, _Scope.Offset, tLen),
					0
				);
		}

		public void ExitScope()
		{
			_Scope = _ScopeStack.Pop();
		}

		private class BdRawSerializeScope : BdRawSerializeScopeSnapshot
		{
			public BdRawSerializeScope(MemBlock buffer, MemOffset offset)
				:base(buffer, offset){}

			public BdRawSerializeScope(BdRawSerializeScopeSnapshot snapshot)
				: base(snapshot)
			{
			}

			public new MemOffset Offset
			{
				get
				{
					return base.Offset;
				}
				set
				{
					base.Offset = value;
				}
			}
		}

		private class BdRawSerializeScopeSnapshot
		{
			public BdRawSerializeScopeSnapshot(MemBlock buffer, MemOffset offset)
			{
				Buffer = buffer;
				Offset = offset;
			}

			public BdRawSerializeScopeSnapshot(BdRawSerializeScopeSnapshot snapshot)
			{
				Buffer = snapshot.Buffer;
				Offset = snapshot.Offset;
			}

			public MemBlock Buffer { get; private set; }
			public MemOffset Offset { get; protected set; }
		}

		#endregion Scope

		public void Serialize<T>(T instance) where T : IBdRawSerializable, new()
		{
			IBdRawSerializable tObjectSerializalbe = instance as IBdRawSerializable;
			if (tObjectSerializalbe == null)
			{
				_Scope.Buffer.WriteStructure(_Scope.Offset, instance);
				_Scope.Offset += Marshal.SizeOf(instance);
			}
			else
			{
				long tOffset;
				this.EnterScope(tObjectSerializalbe.Length);
				try
				{
					tOffset = tObjectSerializalbe.SerializeTo(this);
				}
				finally
				{
					this.ExitScope();
				}

				_Scope.Offset += tOffset;
			}
		}

		public T Deserialize<T>() where T : new()
		{
			T tObject = new T();

			IBdRawSerializable tObjectSerializalbe = tObject as IBdRawSerializable;
			if (tObjectSerializalbe == null)
			{
				_Scope.Buffer.CopyToStructure(_Scope.Offset, tObject);
				_Scope.Offset += Marshal.SizeOf(tObject);
			}
			else
			{
				long tOffset;
				this.EnterScope();
				try
				{
					tOffset = tObjectSerializalbe.DeserializeFrom(this);
				}
				finally
				{
					this.ExitScope();
				}

				_Scope.Offset += tOffset;
			}

			return tObject;
		}

		#region Deserialize

		private byte[] DeserializeBytesReversed(int len)
		{
			byte[] tBuffer = this.DeserializeBytes(len);

			tBuffer = tBuffer.Reverse().ToArray();
			return tBuffer;
		}

		public byte DeserializeByte()
		{
			byte tRet = this.DeserializeBytes(1)[0];

			return tRet;
		}

		public ushort DeserializeUInt16()
		{
			byte[] tBuffer = DeserializeBytesReversed(2);

			return BitConverter.ToUInt16(tBuffer, 0);
		}

		public uint DeserializeUInt32()
		{
			byte[] tBuffer = DeserializeBytesReversed(4);

			return BitConverter.ToUInt32(tBuffer, 0);
		}

		public ulong DeserializeUInt64()
		{
			byte[] tBuffer = DeserializeBytesReversed(8);

			return BitConverter.ToUInt64(tBuffer, 0);
		}

		public byte[] DeserializeBytes(int len)
		{
			byte[] tBuffer = new byte[len];

			_Scope.Buffer.CopyTo(_Scope.Offset, tBuffer, 0, len);
			_Scope.Offset += len;

			return tBuffer;
		}

		public string DeserializeString(int len)
		{
			return Encoding.UTF8.GetString(this.DeserializeBytes(len));
		}

		#endregion Deserialize

		#region Serialize

		private void SerializeBytesReversed(byte[] bytes)
		{
			byte[] tBuffer = bytes.Reverse().ToArray();
			this.Serialize(tBuffer);
		}

		public void Serialize(byte value)
		{
			Serialize(new byte[1]{value});
		}

		public void Serialize(ushort value)
		{
			SerializeBytesReversed(BitConverter.GetBytes(value));
		}

		public void Serialize(uint value)
		{
			this.SerializeBytesReversed(BitConverter.GetBytes(value));
		}

		public void Serialize(ulong value)
		{
			this.SerializeBytesReversed(BitConverter.GetBytes(value));
		}

		public void Serialize(byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			_Scope.Buffer.CopyFrom(_Scope.Offset, value, 0, value.Length);
			_Scope.Offset += value.Length;
		}
		#endregion
	}
}
