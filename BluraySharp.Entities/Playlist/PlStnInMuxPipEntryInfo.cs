/* ****************************************************************************
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
	public class PlStnInMuxPipEntryInfo : BdPart, IPlStnInMuxPipEntryInfo
	{
		[BdUIntField(BdIntSize.U8)]
		public byte SubPathId
		{
			get;
			set;
		}

		[BdUIntField(BdIntSize.U16)]
		public ushort StreamProgId
		{
			get;
			set;
		}

		private byte[] reservedForFutureUse = new byte[5];
		[BdByteArrayField]
		public byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Entry refering a InMuxPip subpath";
		}
	}
}
