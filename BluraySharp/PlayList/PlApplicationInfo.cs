using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibElfin.WinApi.MemoryBlock;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlApplicationInfo : IBdRawSerializable
	{
		private readonly uint _DataLen = 14;
		private byte Reserved { get; set; }
		public byte PlayBackType { get; set; }
		public ushort PlayBackCount { get; set; }
		public BdUOMask UOMask { get; private set; }
		public ushort PlayBackFlags { get; set; } //TODO: define a class

		public long SerializeTo(BdRawSerializeContext context)
		{
			context.Serialize(_DataLen);

			context.EnterScope(_DataLen);
			try
			{
				context.Serialize(Reserved);

				context.Serialize(PlayBackType);
				context.Serialize(PlayBackCount);
				context.Serialize<BdUOMask>(UOMask);
				context.Serialize(PlayBackFlags);
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += _DataLen;
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			uint tDataLen = context.DeserializeUInt32();

			context.EnterScope();
			try
			{
				Reserved = context.DeserializeByte();
				PlayBackType = context.DeserializeByte();
				PlayBackCount = context.DeserializeUInt16();

				UOMask = context.Deserialize<BdUOMask>();

				PlayBackFlags = context.DeserializeUInt16();
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long RawLength
		{
			get {
				return _DataLen + 4; 
			}
		}
	}
}
