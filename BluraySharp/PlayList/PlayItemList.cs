using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.PlayList
{
	public class PlayItemList : IBdRawSerializable
	{
		private ushort Reserved
		{
			get;
			set;
		}

		public IList<PlayItem> PlayItems
		{
			get;
			private set;
		}

		public IList<SubPath> SubPaths
		{
			get;
			private set;
		}

		public long SerializeTo(BdRawSerializeContext context)
		{
			//throw new NotImplementedException();
			System.Diagnostics.Debug.Print("PlayItemList.Sz");
			return 0;
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

				PlayItems = new List<PlayItem>();
				for (uint i = 0; i < tPlayItemCount; ++i)
				{
					PlayItems.Add(context.Deserialize<PlayItem>());
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long Length
		{
			get { throw new NotImplementedException(); }
		}
	}
}
