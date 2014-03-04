using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;
using System.Diagnostics;
using System.Linq;
namespace BluraySharp.PlayList
{
	public class PlPlayItemList : BluraySharp.PlayList.IPlPlayItemList
	{
		private byte[] value = new byte[0];

		[BdUIntField(BdIntSize.U32)]
		public uint DataLen
		{
			get { return (uint)this.value.Length; }
			set { Array.Resize(ref this.value, (int)value); }
		}

		[BdByteArrayField]
		public byte[] Value
		{
			get { return this.value; }
			set { this.value = value; }
		}

		public override string ToString()
		{
			return "PlayItemList";
		}

		//public long DeserializeFrom(IBdRawReadContext context)
		//{
		//	uint tDataLen;

		//	//-tDataLen = context.DeserializeUInt32();
		//	//-context.EnterScope(tDataLen);

		//	try
		//	{
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
	}
}
