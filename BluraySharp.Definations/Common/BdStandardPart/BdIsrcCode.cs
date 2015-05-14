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

using BluraySharp.Common.BdPartFramework;
using System;
using System.Text;

namespace BluraySharp.Common.BdStandardPart
{
	public class BdIsrcCode : BdPart
	{
		#region CountryCode

		private const string countryCodeConst = "00";
		private const int countryCodeLength = 2;
		private string countryCode = countryCodeConst;

		[BdStringField(countryCodeLength, BdCharacterCodingType.UTF8)]
		public string CountryCode
		{
			get { return this.countryCode; }
			set
			{
				this.countryCode = (string.IsNullOrEmpty(value) || value.Length > countryCodeLength)
					? countryCodeConst
					: value;
			}
		}

		#endregion

		#region YearCode

		private const string yearCodeConst = "00";
		private const int yearCodeLength = 2;
		private string yearCode = yearCodeConst;

		[BdStringField(yearCodeLength, BdCharacterCodingType.UTF8)]
		public string YearCode
		{
			get { return this.yearCode; }
			set
			{
				this.yearCode = (string.IsNullOrEmpty(value) || value.Length > yearCodeLength)
					? yearCodeConst
					: value;
			}
		}

		#endregion

		#region OwnerCode

		private const string ownerCodeConst = "000";
		private const int ownerCodeLength = 3;
		private string ownerCode = ownerCodeConst;

		[BdStringField(ownerCodeLength, BdCharacterCodingType.UTF8)]
		public string OwnerCode
		{
			get { return this.ownerCode; }
			set
			{
				this.ownerCode = (string.IsNullOrEmpty(value) || value.Length > ownerCodeLength)
					? ownerCodeConst
					: value;
			}
		}

		#endregion

		#region RecordingCode

		private const string recordingCodeConst = "0000";
		private const int recordingCodeLength = 4;
		private string recordingCode = recordingCodeConst;

		[BdStringField(recordingCodeLength, BdCharacterCodingType.UTF8)]
		public string RecordingCode
		{
			get { return this.recordingCode; }
			set
			{
				this.recordingCode = (string.IsNullOrEmpty(value) || value.Length > recordingCodeLength)
					? recordingCodeConst
					: value;
			}
		}

		#endregion

		#region ItemCode

		private const string itemCodeConst = "0";
		private const int itemCodeLength = 1;
		private string itemCode = itemCodeConst;

		[BdStringField(itemCodeLength, BdCharacterCodingType.UTF8)]
		public string ItemCode
		{
			get { return this.itemCode; }
			set
			{
				this.itemCode = (string.IsNullOrEmpty(value) || value.Length > itemCodeLength)
					? itemCodeConst
					: value;
			}
		}

		#endregion

		public override string ToString()
		{
			return string.Join("-", this.CountryCode, this.OwnerCode, this.YearCode, this.RecordingCode, this.ItemCode);
		}
	}
}
