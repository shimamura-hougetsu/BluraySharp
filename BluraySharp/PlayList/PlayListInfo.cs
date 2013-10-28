using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibElfin.WinApi.MemoryBlock;

namespace BluraySharp.PlayList
{
	public class PlayListInfo : IBdRawSerializable
	{
		private readonly uint _DataLen = 14;
		private byte Reserved { get; set; }
		public byte PlayBackType { get; set; }
		public ushort PlayBackCount { get; set; }
		public UOMask UOMask { get; private set; }
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
				context.Serialize<UOMask>(UOMask);
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

				UOMask = context.Deserialize<UOMask>();

				PlayBackFlags = context.DeserializeUInt16();
			}
			finally
			{
				context.ExitScope();
			}

			return context.Offset += tDataLen;
		}

		public long Length
		{
			get {
				return _DataLen + 4; 
			}
		}
	}
}
