using BluraySharp.Common.BdPartFramework;
using System;

namespace BluraySharp.Common.BdStandardPart
{
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
