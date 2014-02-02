using System;

namespace BluraySharp.Common
{
	public class BdExtensionData : IBdPart
	{
		private byte[] value = new byte[0];

		public long SerializeTo(IBdRawIoContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			uint tDataLen;
			tDataLen = context.DeserializeUInt32();

			if (tDataLen > 0)
			{
				context.EnterScope(tDataLen);

				try
				{
					this.value = context.DeserializeBytes((int)tDataLen);
				}
				finally
				{
					context.ExitScope();
				}
			}

			return context.Offset += tDataLen;
		}

		public long RawLength
		{
			get
			{
				if (this.value != null && this.value.Length > 0)
				{
					return this.value.Length + sizeof(uint);
				}
				else
				{
					return 0;
				}
			}
		}
	}
}
