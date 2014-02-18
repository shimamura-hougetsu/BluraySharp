using System;
using System.Collections.Generic;
using BluraySharp.Architecture;

namespace BluraySharp.PlayList
{
	public class PlPlayItemList : BluraySharp.PlayList.IPlPlayItemList
	{
		public IBdList<IPlPlayItem> PlayItems { get; internal set; }

		public IBdList<IPlSubPath> SubPaths { get; internal set; }

		internal ushort ReservedForFutureUse { get; set; }

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			uint tDataLen;

			//-tDataLen = context.DeserializeUInt32();
			//-context.EnterScope(tDataLen);

			try
			{
				//-this.ReservedForFutureUse = context.DeserializeUInt16();

				//-uint tPlayItemCount = context.DeserializeUInt16();
				//-uint tSubPathCount = context.DeserializeUInt16();

				PlayItems.Clear();
				//-for (uint i = 0; i < tPlayItemCount; ++i)
				{
					PlayItems.Insert(context.Deserialize<PlPlayItem>());
				}

				SubPaths.Clear();
				//-for (uint i = 0; i < tSubPathCount; ++i)
				{
					SubPaths.Insert(context.Deserialize<PlSubPath>());
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
		}

		public long RawLength
		{
			get
			{
				long tDataLen = sizeof(uint);
				tDataLen += sizeof(ushort);

				foreach (IBdPart tObj in this.PlayItems)
				{
					tDataLen += tObj.RawLength;
				}

				foreach (IBdPart tObj in this.SubPaths)
				{
					tDataLen += tObj.RawLength;
				}

				return tDataLen;
			}
		}

		public PlPlayItemList()
		{
			PlayItems = new BdPartList<PlPlayItem, IPlPlayItem>(999);
			SubPaths = new BdPartList<PlSubPath, IPlSubPath>(255);
		}
	}
}
