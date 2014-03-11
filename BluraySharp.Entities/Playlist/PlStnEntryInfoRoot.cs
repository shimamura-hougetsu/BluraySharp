using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	[BdPartScope(BdIntSize.U8)]
	internal class PlStnEntryInfoRoot : BdPart
	{
		public PlStnEntryInfoRoot(PlStnStreamEntryType entryType)
		{
			this.EntryType = entryType;
		}

		#region
		
		private PlStnStreamEntryType entryType;
		private IPlStnEntryInfo entryInfo;

		#endregion

		[BdUIntField(BdIntSize.U8)]
		public PlStnStreamEntryType EntryType
		{
			get
			{
				return this.entryType;
			}
			set
			{
				if (this.entryType != value)
				{
					this.UpdateEntryType(value);
				}
			}
		}

		[BdSubPartField]
		public IPlStnEntryInfo EntryInfo
		{
			get { return this.entryInfo; }
		}

		private void UpdateEntryType(PlStnStreamEntryType type)
		{
			switch (type)
			{
				case PlStnStreamEntryType.PlayItem:
					this.entryInfo = new PlStnPlayItemEntryInfo();
					break;
				case PlStnStreamEntryType.SubPlayItem:
					this.entryInfo = new PlStnSubPlayItemEntryInfo();
					break;
				case PlStnStreamEntryType.InMuxPip:
					this.entryInfo = new PlStnInMuxPipEntryInfo();
					break;
				default:
					throw new ArgumentException("value");
			}
			
			this.entryType = type;
		}


		public override string ToString()
		{
			return "Internal StnEntryInfo Serializing Helper";
		}
	}
}
