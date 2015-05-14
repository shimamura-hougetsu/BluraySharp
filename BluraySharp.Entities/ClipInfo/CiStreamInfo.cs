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

namespace BluraySharp.ClipInfo
{
	public class CiStreamInfo : BdPart, ICiStreamInfo
	{
		#region PID

		[BdUIntField(BdIntSize.U16)]
		public ushort Pid { get; set; }

		#endregion

		#region CodingInfo

		private CiStreamCodingInfo codingInfo = new CiStreamCodingInfo();

		[BdSubPartField]
		private CiStreamCodingInfo CodingInfo
		{
			get { return this.codingInfo; }
		}

		public BdStreamCodingType CodingType
		{
			get { return this.CodingInfo.CodingType; }
			set { this.CodingInfo.CodingType = value; }
		}

		public ICiStreamAttrInfo CodingAttr
		{
			get { return this.CodingInfo.CodingAttr; }
		}

		#endregion

		public override string ToString()
		{
			return "Stream in a program sequence";
		}


	}
}
