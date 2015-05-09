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

namespace BluraySharp.Common.BdStandardPart
{
	/// <summary>
	/// Referer to a clip file
	/// </summary>
	public class BdClipFileRef : BdPart
	{
		#region ClipIdString

		[BdStringField(5, Common.BdCharacterCodingType.UTF8)]
		private string ClipIdString
		{
			get { return this.ClipId.ToString("00000"); }
			set { this.ClipId = uint.Parse(value); }
		}
		public uint ClipId { get; set; }

		#endregion

		#region ClipCodec

		private const string clipCodecConst = "M2TS";
		private string clipCodec = BdClipFileRef.clipCodecConst;

		[BdStringField(4, Common.BdCharacterCodingType.UTF8)]
		public string ClipCodec
		{
			get { return this.clipCodec; }
			set
			{
				if (!BdClipFileRef.clipCodecConst.Equals(value))
				{
					//TODO: Invalid codec
					throw new ArgumentException();
				}
				this.clipCodec = value;
			}
		}

		#endregion

		public override string ToString()
		{
			return string.Format("ClipRef: {0}.{1}", this.ClipIdString, this.ClipCodec);
		}
	}
}
