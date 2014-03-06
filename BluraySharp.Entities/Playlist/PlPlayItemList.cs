using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;
namespace BluraySharp.PlayList
{
	public class PlPlayItemList : BdPart, IPlPlayItemList
	{
		#region Private Data Fields

		private ushort reservedForFutureUse = 0;
		private ushort playItemCount = 0;
		private ushort subPathCount = 0;

		private BdPartList<PlPlayItem, IPlPlayItem> playItems = new BdPartList<PlPlayItem, IPlPlayItem>(0, 999);
		private BdPartList<PlSubPath, IPlSubPath> subPaths = new BdPartList<PlSubPath, IPlSubPath>(0, 255);

		#endregion Private Data Fields

		public IBdList<IPlPlayItem> PlayItems
		{
			get { throw new NotImplementedException(); }
		}

		public IBdList<IPlSubPath> SubPaths
		{
			get { throw new NotImplementedException(); }
		}


		//		//-this.ReservedForFutureUse = context.DeserializeUInt16();

		//		//-uint tPlayItemCount = context.DeserializeUInt16();
		//		//-uint tSubPathCount = context.DeserializeUInt16();

		//		PlayItems.Clear();
		//		//-for (uint i = 0; i < tPlayItemCount; ++i)
		//		{
		//			PlayItems.Insert(context.Deserialize<PlPlayItem>());
		//		}

		//		SubPaths.Clear();
		//		//-for (uint i = 0; i < tSubPathCount; ++i)
		//		{
		//			SubPaths.Insert(context.Deserialize<PlSubPath>());
		//		}
		//	}
		//	finally
		//	{
		//		context.ExitScope();
		//	}

		//	return context.Position;
		//}

		public override string ToString()
		{
			throw new NotImplementedException();
		}
	}
}
