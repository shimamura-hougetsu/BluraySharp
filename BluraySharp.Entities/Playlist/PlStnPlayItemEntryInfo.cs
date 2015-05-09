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
	public class PlStnPlayItemEntryInfo : BdPart, IPlStnPlayItemEntryInfo
	{
		[BdUIntField(BdIntSize.U16)]
		public ushort StreamProgId
		{
			get;
			set;
		}

		private byte[] reservedForFutureUse = new byte[6];
		[BdByteArrayField]
		private byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Entry Refering a PlayItem";
		}
	}
}
