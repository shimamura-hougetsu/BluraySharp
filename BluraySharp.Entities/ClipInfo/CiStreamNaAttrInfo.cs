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

namespace BluraySharp.ClipInfo
{
	public class CiStreamNaAttrInfo: BdPart, ICiStreamAttrInfo
	{
		#region ReservedForFutureUse

		[BdUIntField(BdIntSize.U32)]
		private uint ReservedForFutureUse { get; set; }

		#endregion

		#region ISRC

		private BdIsrcCode isrc = new BdIsrcCode();

		[BdSubPartField]
		public BdIsrcCode ISRC
		{
			get { return this.isrc; }
		}

		#endregion

		#region ReservedForFutureUse2

		[BdUIntField(BdIntSize.U32)]
		private uint ReservedForFutureUse2 { get; set; }

		#endregion
		public override string ToString()
		{
			return "Stream Attributes for unknown coding types.";
		}
	}
}
