using System;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlMarkList : BluraySharp.PlayList.IPlMarkList
	{
		private byte[] value = new byte[0];

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			uint tDataLen;

			tDataLen = context.DeserializeUInt32();

			if (tDataLen > 0)
			{
				context.EnterScope(tDataLen);

				try
				{
					value = context.DeserializeBytes((int)tDataLen);
				}
				finally
				{
					context.ExitScope();
				}
			}

			return context.Position;
		}


		public long RawLength
		{
			get
			{
				if (value != null && value.Length > 0)
				{
					return value.Length + sizeof(uint);
				}
				else
				{
					return 0;
				}
			}
		}
	}
}
