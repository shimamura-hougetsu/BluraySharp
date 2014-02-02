using System;
using System.Collections.Generic;

namespace BluraySharp.Playlist
{
	public class PlPlayItemList : BluraySharp.Playlist.IPlPlayItemList
	{

		public IPlPlayItem CreatePlayItem()
		{
			return new PlPlayItem();
		}

		public IPlSubPath CreateSubPath()
		{
			return new PlSubPath();
		}

		public IList<IPlPlayItem> PlayItems
		{
			get
			{
				return new List<IPlPlayItem>(this.PlayItemsX);
			}
		}

		public IList<IPlSubPath> SubPaths
		{
			get
			{
				return new List<IPlSubPath>(this.SubPathsX);
			}
		}

		private ushort ReservedForFutureUse { get; set; }

		public IList<PlPlayItem> PlayItemsX { get; private set; }

		public IList<PlSubPath> SubPathsX { get; private set; }

		public long SerializeTo(IBdRawIoContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawIoContext context)
		{
			uint tDataLen;

			tDataLen = context.DeserializeUInt32();
			context.EnterScope(tDataLen);

			try
			{
				this.ReservedForFutureUse = context.DeserializeUInt16();

				uint tPlayItemCount = context.DeserializeUInt16();
				uint tSubPathCount = context.DeserializeUInt16();

				PlayItemsX.Clear();
				for (uint i = 0; i < tPlayItemCount; ++i)
				{
					PlayItemsX.Add(context.Deserialize<PlPlayItem>());
				}

				SubPathsX.Clear();
				for (uint i = 0; i < tSubPathCount; ++i)
				{
					SubPathsX.Add(context.Deserialize<PlSubPath>());
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

				foreach (IBdPart tObj in this.PlayItemsX)
				{
					tDataLen += tObj.RawLength;
				}

				foreach (IBdPart tObj in this.SubPathsX)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}

		public PlPlayItemList()
		{
			PlayItemsX = new List<PlPlayItem>();
			SubPathsX = new List<PlSubPath>();
		}
	}
}
