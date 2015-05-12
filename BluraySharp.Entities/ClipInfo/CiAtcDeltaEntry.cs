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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	public class CiAtcDeltaEntry : BdPart, ICiAtcDeltaEntry
	{
		#region AtcDelta

		[BdUIntField(BdIntSize.U32)]
		public ulong AtcDelta { get; set; }

		#endregion

		#region FollowingClip

		private BdClipFileRef followingClip = new BdClipFileRef();

		[BdSubPartField]
		public BdClipFileRef FollowingClip
		{
			get { return this.followingClip; }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte reservedForFutureUse { get; set; }

		#endregion

		public override string ToString()
		{
			return string.Format("ATC Delta: {0} ({1})", this.AtcDelta, this.followingClip.ToString());
		}
	}
}
