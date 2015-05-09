/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;

namespace BluraySharp.PlayList
{
	internal class PlStnEntryRoot : BdPart
	{
		public PlStnEntryRoot(PlStnEntryType entryType, BdStreamCodingType attrType)
		{
			this.EntryInfoRoot = new PlStnEntryInfoRoot(entryType);
			this.AttrInfoRoot = new PlStnAttrInfoRoot(attrType);
		}

		#region EntryInfo Root

		[BdSubPartField]
		private PlStnEntryInfoRoot EntryInfoRoot { get; set; }

		public PlStnEntryType EntryType
		{
			get { return this.EntryInfoRoot.EntryType; }
			set { this.EntryInfoRoot.EntryType = value; }
		}
		public IPlStnEntryInfo EntryInfo
		{
			get { return this.EntryInfoRoot.EntryInfo; }
		}

		#endregion
		
		#region AttrInfo Root

		[BdSubPartField]
		private PlStnAttrInfoRoot AttrInfoRoot { get; set; }

		public BdStreamCodingType AttrInfoType
		{
			get { return this.AttrInfoRoot.AttrInfoType; }
			set { this.AttrInfoRoot.AttrInfoType = value; }
		}
		public IPlStnAttrInfo AttrInfo
		{
			get { return this.AttrInfoRoot.AttrInfo; }
		}

		#endregion

		public override string ToString()
		{
			return "Internal StnEntry Serializing Helper";
		}
	}
}
