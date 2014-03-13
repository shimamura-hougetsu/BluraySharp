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
		public PlStnEntryInfoRoot(PlStnEntryType entryType)
		{
			this.UpdateEntryType(entryType);
		}

		#region EntryType

		private PlStnEntryType entryType;

		[BdUIntField(BdIntSize.U8)]
		public PlStnEntryType EntryType
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


		private void UpdateEntryType(PlStnEntryType type)
		{
			switch (type)
			{
				case PlStnEntryType.PlayItem:
					this.entryInfo = new PlStnPlayItemEntryInfo();
					break;
				case PlStnEntryType.SubPlayItem:
					this.entryInfo = new PlStnSubPlayItemEntryInfo();
					break;
				case PlStnEntryType.InMuxPip:
					this.entryInfo = new PlStnInMuxPipEntryInfo();
					break;
				default:
					throw new ArgumentException("value");
			}

			this.entryType = type;
		}


		#endregion

		#region EntryInfo

		private IPlStnEntryInfo entryInfo;

		[BdSubPartField]
		public IPlStnEntryInfo EntryInfo
		{
			get { return this.entryInfo; }
		}

		#endregion

		public override string ToString()
		{
			return "Internal StnEntryInfo Serializing Helper";
		}
	}
}
