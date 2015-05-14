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
	[BdPartScope(BdIntSize.U32)]
	public class CiProgramInfo : BdPart, ICiProgramInfo
	{
		/*
		private byte[] value = new byte[0];

		public uint LengthIndicator
		{
			get { return (uint)this.value.Length; }
			set { Array.Resize(ref this.value, (int)value); }
		}

		[BdByteArrayField]
		public byte[] Value
		{
			get { return this.value; }
			set { this.value = value; }
		}*/

		#region Sequences

		[BdUIntField(BdIntSize.U8)]
		private byte reservedForFutureUse { get; set; }

		[BdUIntField(BdIntSize.U8)]
		private byte sequencesCount
		{
			get { return (byte) this.sequences.Count; }
			set { this.Sequences.SetCount(value); }
		}

		private BdList<CiProgramSequence, ICiProgramSequence> sequences =
			new BdList<CiProgramSequence, ICiProgramSequence>(0, 1);

		[BdSubPartField]
		public IBdList<ICiProgramSequence> Sequences
		{
			get { return this.sequences; }
		}

		#endregion

		public override string ToString()
		{
			return "CiProgramInfo";
		}

	}
}
