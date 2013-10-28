using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.PlayList
{
	public class UOMask : IBdRawSerializable
	{
		private ulong _Value = 0;

		public long SerializeTo(BdRawSerializeContext context)
		{
			context.Serialize(_Value);

			return context.Offset;
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_Value = context.DeserializeUInt64();

			return context.Offset;
		}


		public long Length
		{
			get
			{
				return sizeof(ulong);
			}
		}
	}
}
