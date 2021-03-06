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
	[BdPartScope(BdIntSize.U32)]
	public class CiSequenceInfo : BdPart, ICiSequenceInfo
	{
		#region ReservedForFutureUse

		[BdUIntField(BdIntSize.U8)]
		private byte reservedForFutureUse { get; set; }

		#endregion

		#region AtcSequenceList

		[BdUIntField(BdIntSize.U8)]
		private byte AtcSequenceEntryCount
		{
			get
			{
				return (byte)this.AtcSequenceList.Count;
			}
			set
			{
				this.atcSequenceList.SetCount(value);
			}
		}

		private BdList<CiAtcSequence, ICiAtcSequence> atcSequenceList =
			new BdList<CiAtcSequence, ICiAtcSequence>(0, 1);

		[BdSubPartField]
		public IBdList<ICiAtcSequence> AtcSequenceList
		{
			get { return this.atcSequenceList; }
		}

		#endregion

		public override string ToString()
		{
			return "SequenceInfo";
		}

	}
}
