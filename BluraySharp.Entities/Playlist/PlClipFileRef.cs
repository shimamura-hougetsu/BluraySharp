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
		private string clipCodec = PlClipFileRef.clipCodecConst;

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

		#endregion

		public override string ToString()
		{
			return string.Format("ClipRef: {0:00000}.{1}", this.ClipId, this.ClipCodec);
		}
	}
}
