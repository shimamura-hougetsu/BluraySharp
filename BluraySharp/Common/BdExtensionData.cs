using System;

namespace BluraySharp.Common
{
	public class BdExtensionData : IBdRawSerializable
	{
		private byte[] _Value = new byte[0];

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			uint tDataLen;
			tDataLen = context.DeserializeUInt32();

			if (tDataLen > 0)
			{
				context.EnterScope(tDataLen);

				try
				{
					_Value = context.DeserializeBytes((int)tDataLen);
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
				if (_Value != null && _Value.Length > 0)
				{
					return _Value.Length + sizeof(uint);
				}
				else
				{
					return 0;
				}
			}
		}
	}
}
