using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public interface IBdRawWriteContext : IBdRawIoContext
	{
		void Serialize<T>(T obj) where T : IBdRawSerializable;

		void Serialize(byte[] value, int offset, int length);

		void Serialize(string value);

		void Serialize(byte value);
		void Serialize(ushort value);
		void Serialize(uint value);
		void Serialize(ulong value);
	}
}
