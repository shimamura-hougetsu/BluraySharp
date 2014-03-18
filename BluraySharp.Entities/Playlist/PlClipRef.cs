using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.BdStandardPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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