using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public interface IBdRawReadContext : IBdRawIoContext
	{
		void Deserialize(IBdRawSerializable obj);

		void Deserialize(byte[] value);
		void Deserialize(byte[] value, int offset, int length);
		
		ulong Deserialize(BdIntSize intSize);
	}
}
