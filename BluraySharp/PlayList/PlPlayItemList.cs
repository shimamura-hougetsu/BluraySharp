using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.PlayList
{
	public class PlPlayItemList : IBdRawSerializable
	{
		private ushort Reserved
		{
			get;
			set;
		}

		public IList<PlPlayItem> PlayItems
		{
			get;
			private set;
		}

		public IList<PlSubPath> SubPaths
		{
			get;
			private set;
		}

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
			get { throw new NotImplementedException(); }
		}

		public PlPlayItemList()
		{
			PlayItems = new List<PlPlayItem>();
			SubPaths = new List<PlSubPath>();
		}
	}
}
