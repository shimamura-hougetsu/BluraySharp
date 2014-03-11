using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlClipRef : BdPart, IPlClipRef
	{
		#region ClipFileRef

		private PlClipFileRef clipFileId = new PlClipFileRef();

		[BdSubPartField]
		public IPlClipFileRef ClipFileRef
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