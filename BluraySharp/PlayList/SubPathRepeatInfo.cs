using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class SubPathRepeatInfo : IBdRawSerializable
	{
		private ushort _Value = 0;

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			_Value = context.DeserializeUInt16();

			return context.Offset;
		}

		public long Length
		{
			get { throw new NotImplementedException(); }
		}
	}
}
