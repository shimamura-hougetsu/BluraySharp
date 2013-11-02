using System;
using System.Collections.Generic;

namespace BluraySharp.PlayList
{
	public class PlPlayItemList : IBdRawSerializable
	{
		private ushort Reserved { get; set; }

		public IList<PlPlayItem> PlayItems { get; private set; }

		public IList<PlSubPath> SubPaths { get; private set; }

		public long SerializeTo(BdRawSerializeContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			uint tDataLen;

			tDataLen = context.DeserializeUInt32();
			context.EnterScope(tDataLen);

			try
			{
				Reserved = context.DeserializeUInt16();

				uint tPlayItemCount = context.DeserializeUInt16();
				uint tSubPathCount = context.DeserializeUInt16();

				PlayItems.Clear();
				for (uint i = 0; i < tPlayItemCount; ++i)
				{
					PlayItems.Add(context.Deserialize<PlPlayItem>());
				}

				SubPaths.Clear();
				for (uint i = 0; i < tSubPathCount; ++i)
				{
					SubPaths.Add(context.Deserialize<PlSubPath>());
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long RawLength
		{
			get
			{
				long tDataLen = sizeof(uint);
				tDataLen += sizeof(ushort);

				foreach (IBdRawSerializable tObj in this.PlayItems)
				{
					tDataLen += tObj.RawLength;
				}

				foreach (IBdRawSerializable tObj in this.SubPaths)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}

		public PlPlayItemList()
		{
			PlayItems = new List<PlPlayItem>();
			SubPaths = new List<PlSubPath>();
		}
	}
}
