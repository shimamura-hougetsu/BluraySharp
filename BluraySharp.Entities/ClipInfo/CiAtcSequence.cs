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
	public class CiAtcSequence : BdPart, ICiAtcSequence
	{
		#region SpnStcStart

		[BdUIntField(BdIntSize.U32)]
		public uint SpnAtcStart { get; set; }

		#endregion

		#region StcSequenceList

		[BdUIntField(BdIntSize.U8)]
		private byte StcSequenceEntryCount
		{
			get
			{
				return (byte)this.StcSequenceList.Count;
			}
			set
			{
				this.stcSequenceList.SetCount(value);
			}
		}

		private BdList<CiStcSequence, ICiStcSequence> stcSequenceList =
			new BdList<CiStcSequence, ICiStcSequence>(0, 255);


		[BdUIntField(BdIntSize.U8)]
		public byte OffsetStcId { get; set; }


		[BdSubPartField]
		public IBdList<ICiStcSequence> StcSequenceList
		{
			get { return this.stcSequenceList; }
		}

		#endregion

		public override string ToString()
		{
			return "ATC Sequence";
		}
	}
}
