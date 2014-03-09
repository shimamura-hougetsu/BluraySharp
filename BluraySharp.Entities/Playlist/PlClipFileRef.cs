using System;
using BluraySharp.Architecture;
using System.Text;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common;
using BluraySharp.Common.BdStandardPart;

namespace BluraySharp.PlayList
{
	public class PlClipFileRef : BdPart, IPlClipFileRef
	{
		private uint clipId = 0;

		private const string clipCodecConst = "M2TS";
		private string clipCodec = PlClipFileRef.clipCodecConst;

		[BdStringField(5, Common.BdCharacterCodingType.UTF8)]
		private string ClipIdString
		{
			get { return this.clipId.ToString("00000"); }
			set { this.clipId = uint.Parse(value); }
		}
		public uint ClipId
		{
			get { return this.clipId; }
			set { this.clipId = value; }
		}

		[BdStringField(4, Common.BdCharacterCodingType.UTF8)]
		public string ClipCodec
		{
			get { return this.clipCodec; }
			set
			{
				if (!PlClipFileRef.clipCodecConst.Equals(value))
				{
					//TODO: Invalid codec
					throw new ArgumentException();
				}
				this.clipCodec = value;
			}
		}

		public override string ToString()
		{
			return string.Format("ClipRef: {0:00000}.{1}", this.ClipId, this.ClipCodec);
		}
	}
}
