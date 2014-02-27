using System;
using BluraySharp.Serializing;

namespace BluraySharp.Common
{
	public class BdExtensionData : IBdPart
	{
		private byte[] value = new byte[0];

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			uint tDataLen = 0;
			//-tDataLen = context.DeserializeUInt32();

			if (tDataLen > 0)
			{
				context.EnterScope(tDataLen);

				try
				{
					//this.value = context.Deserialize((int)tDataLen);
					context.Deserialize(value);
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
