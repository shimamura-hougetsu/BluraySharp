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
	public class PlStnStEntry : BdPart, IPlStnStEntry
	{
		#region Entry Root
		private PlStnEntryRoot entryRoot =
			new PlStnEntryRoot(
				PlStnEntryType.PlayItem, 
				(BdStreamCodingType) BdStCodingType.GxPresentation
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
		public BdStCodingType AttrInfoType
		{
			get { return (BdStCodingType) this.entryRoot.AttrInfoType; }
			set { this.entryRoot.AttrInfoType = (BdStreamCodingType) value; }
		}
		public IPlStnAttrInfo AttrInfo
		{
			get { return this.entryRoot.AttrInfo; }
		}
		#endregion

		public override string ToString()
		{
			return "Subtitle(Pg/Text) STN Entry";
		}
	}
}
