using BluraySharp.Common;

namespace BluraySharp.ClipInfo
{
	public interface ICiClipInfo : IBdPart
	{
		CiTsType StreamType { get; }
		CiApplicationType ApplicationType { get; set; }

		bool IsAtcDelta { get; set; }
		ulong TsRecodingRate { get; set; }
		ulong SourcePacketsCount { get; set; }

		ICiTsTypeInfo TsTypeInfo { get; }
		IBdList<ICiAtcDeltaEntry> AtcDeltaList { get; }
		IBdList<ICiAppFontRef> AppFontRefList { get; }
	}
}
