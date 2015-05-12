using BluraySharp.Common.BdPartFramework;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	[BdPartScope(BdIntSize.U32, IndicatorField = "LengthIndicator")]
	public class CiProgramInfo : BdPart, ICiProgramInfo
	{
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
		}
		public override string ToString()
		{
			return "CiProgramInfo (dummy)";
		}
	}
}
