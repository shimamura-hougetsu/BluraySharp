using System;
using System.IO;
using BluraySharp.Architecture;
using BluraySharp.PlayList;
using BluraySharp.Common.Serializing;
using BluraySharp.Common;

namespace BluraySharp
{
	public class BdmvContext
	{	
		public void Copy<T>(T src, T dest) where T : IBdPart
		{
			if (object.ReferenceEquals(dest, null))
			{
				throw new ArgumentNullException("dest");
			}

			if (!object.ReferenceEquals(src, null))
			{
				using (MemoryStream tMem = new MemoryStream())
				{
					IBdRawWriteContext tSerializer = new BdByteStreamWriteContext(tMem);
					tSerializer.Serialize(src);

					tMem.Position = 0;

					IBdRawReadContext tDeserializer = new BdByteStreamReadContext(tMem);
					tDeserializer.Deserialize(dest);
				}
			}
		}
	}
}
