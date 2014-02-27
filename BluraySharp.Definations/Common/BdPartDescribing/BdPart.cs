using BluraySharp.Serializing;

namespace BluraySharp.Common
{
	public class BdPart : IBdPart
	{
		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new System.NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			throw new System.NotImplementedException();
		}

		public long RawLength
		{
			get { throw new System.NotImplementedException(); }
		}
	}
}
