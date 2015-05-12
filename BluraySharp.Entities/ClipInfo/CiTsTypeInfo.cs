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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	[BdPartScope(BdIntSize.U16)]
	public class CiTsTypeInfo : BdPart, ICiTsTypeInfo
	{
		#region ValidityFlags

		private byte validityFlags = 0x80;

		[BdUIntField(BdIntSize.U8)]
		public byte ValidityFlags
		{
			get { return validityFlags;}
			set { validityFlags = value;}
		}

		#endregion

		#region FormatIdentifier

		private const string formatIdentifierConst = "HDMV";
		private string formatIdentifier = CiTsTypeInfo.formatIdentifierConst;

		[BdStringField(4, BdCharacterCodingType.UTF8)]
		public string FormatIdentifier
		{
			get { return this.formatIdentifier; }
			set
			{
				if (!CiTsTypeInfo.formatIdentifierConst.Equals(value))
				{
					//TODO: Invalid codec
					throw new ArgumentException();
				}
				this.formatIdentifier = value;
			}
		}

		#endregion

		#region NetworkInformation

		private string networkInformation = string.Empty;

		[BdStringField(9, BdCharacterCodingType.UTF8)]
		public string NetworkInformation
		{
			get { return this.formatIdentifier; }
			set { this.formatIdentifier = value; }
		}

		#endregion

		#region StreamFormatName

		private string streamFormatName = string.Empty;

		[BdStringField(16, BdCharacterCodingType.UTF8)]
		public string StreamFormatName
		{
			get { return this.streamFormatName; }
			set { this.streamFormatName = value; }
		}

		#endregion

		public override string ToString()
		{
			return "Stream Type Info Block";
		}
	}
}
