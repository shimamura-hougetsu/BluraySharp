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

namespace BluraySharp.ClipInfo
{
	public class CiStcSequence : BdPart, ICiStcSequence
	{
		#region PcrPid

		[BdUIntField(BdIntSize.U16)]
		public ushort PcrPid { get; set; }

		#endregion

		#region SpnStcStart

		[BdUIntField(BdIntSize.U32)]
		public uint SpnStcStart { get; set; }

		#endregion

		#region PresentationStartTime

		private BdTime presentationStartTime = new BdTime();

		[BdSubPartField]
		public BdTime PresentationStartTime
		{
			get { return this.presentationStartTime; }
			set { this.presentationStartTime.Value = value.Value; }
		}

		#endregion

		#region PresentationEndTime

		private BdTime presentationEndTime = new BdTime();

		[BdSubPartField]
		public BdTime PresentationEndTime
		{
			get { return this.presentationEndTime; }
			set { this.presentationEndTime.Value = value.Value; }
		}

		#endregion

		public override string ToString()
		{
			return "STC Sequence";
		}
	}
}
