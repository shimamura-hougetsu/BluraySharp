using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	public class PlSubPath : BdPart, IPlSubPath
	{
		public Common.IBdList<IPlPlayItemInfo> PlayItems
		{
			get { throw new System.NotImplementedException(); }
		}

		public PlSubPathType Type
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}

		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
	
	/*
			uint tDataLen;

			//-tDataLen = context.DeserializeUInt32();
			//-context.EnterScope(tDataLen);

			try
			{
				//-Reserved1 = context.DeserializeByte();
				//-Type = (PlSubPathType) context.DeserializeByte();

				repeatOption = context.Deserialize<BdBitwise16>();
				//-Reserved2 = context.DeserializeByte();

				//-byte tSubPlayItemCount = context.DeserializeByte();
				PlayItems.Clear();

				//-for (byte i = 0; i < tSubPlayItemCount; ++i)
				{
					PlayItems.Insert(context.Deserialize<PlSubPlayItem>());
				}
			}
			finally
			{
				context.ExitScope();
			}

			return context.Position;
		}
	}
}*/