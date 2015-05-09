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

using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlClipRef : BdPart, IPlClipRef
	{
		#region ClipFileRef

		private BdClipFileRef clipFileId = new BdClipFileRef();

		[BdSubPartField]
		public BdClipFileRef ClipFileRef
		{
			get { return this.clipFileId; }
		}

		#endregion

		#region StcIdRef

		[BdUIntField(Common.BdIntSize.U8)]
		public byte StcIdRef { get; set; }

		#endregion
		
		public override string ToString()
		{
			return this.ClipFileRef.ToString();
		}
	}
}