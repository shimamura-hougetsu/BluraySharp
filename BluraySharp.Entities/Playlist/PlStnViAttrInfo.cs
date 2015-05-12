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
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlStnViAttrInfo : BdPart, IPlStnViAttrInfo
	{
		#region FormatValue

		private BdBitwise8 formatOptions = new BdBitwise8();

		[BdSubPartField]
		private BdBitwise8 FormatOptions
		{
			get { return this.formatOptions; }
		}
		public BdViFrameRate FrameRate
		{
			get
			{
				return (BdViFrameRate)this.FormatOptions[0, 4];
			}
			set
			{
				this.FormatOptions[0, 4] = (byte)value;
			}
		}
		public BdViFormat VideoFormat
		{
			get
			{
				return (BdViFormat)this.FormatOptions[4, 4];
			}
			set
			{
				this.FormatOptions[4, 4] = (byte)value;
			}
		}		
		#endregion

		#region ReservedForFutureUse

		private byte[] reservedForFutureUse = new byte[3];

		[BdByteArrayField]
		private byte[] ReservedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		#endregion

		public override string ToString()
		{
			return "STN Video AttrInfo";
		}
	}
}
