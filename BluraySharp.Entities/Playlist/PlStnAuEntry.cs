﻿/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	public class PlStnAuEntry : BdPart, IPlStnAuEntry
	{
		#region Entry Root

		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(
				PlStnEntryType.PlayItem, 
				(BdStreamCodingType) BdAuCodingType.AuLPCM
				);

		[BdSubPartField]
		private PlStnEntryRoot EntryRoot
		{
			get { return this.entryRoot; }
		}
		public PlStnEntryType EntryType
		{
			get { return this.entryRoot.EntryType; }
			set { this.entryRoot.EntryType = value; }
		}
		public IPlStnEntryInfo EntryInfo
		{
			get { return this.entryRoot.EntryInfo; }
		}
		public BdAuCodingType AttrInfoType
		{
			get { return (BdAuCodingType)this.entryRoot.AttrInfoType; }
			set { this.entryRoot.AttrInfoType = (BdStreamCodingType)value; }
		}
		public IPlStnAttrInfo AttrInfo
		{
			get { return this.entryRoot.AttrInfo; }
		}

		#endregion

		public override string ToString()
		{
			return "Primary Audio STN Entry";
		}
	}
}
