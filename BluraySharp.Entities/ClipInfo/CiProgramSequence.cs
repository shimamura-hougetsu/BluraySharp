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
	public class CiProgramSequence : BdPart, ICiProgramSequence
	{
		#region StartSpn

		[BdUIntField(BdIntSize.U32)]
		public uint StartSpn { get; set; }

		#endregion

		#region MapPid

		[BdUIntField(BdIntSize.U16)]
		public ushort MapPid { get; set; }

		#endregion

		#region Streams
		
		[BdUIntField(BdIntSize.U8)]
		private byte sequencesCount
		{
			get { return (byte)this.streams.Count; }
			set { this.Streams.SetCount(value); }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte reservedForFutureUse { get; set; }


		private BdList<CiStreamInfo, ICiStreamInfo> streams =
			new BdList<CiStreamInfo, ICiStreamInfo>(0, 129) { new CiStreamInfo() };

		[BdSubPartField]
		public IBdList<ICiStreamInfo> Streams
		{
			get { return this.streams; }
		}

		#endregion

		public override string ToString()
		{
			return "Program Sequance";
		}
	}
}
