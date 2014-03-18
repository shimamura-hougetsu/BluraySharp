using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	[BdmvArrayEntry("PLAYLIST", "mpls", 2000, true)]
	public interface IBdMpls: IBdmvArrayEntry
	{
		string MplsMark { get; }
		string MplsVer { get; set; }

		IPlAppInfo AppInfo { get; }
		IPlPlayItemList PlayItemList { get; }
		IPlPlayMarkList PlayMarkList { get; }
		BluraySharp.Common.BdStandardPart.BdExtensionData ExtensionData { get; set; }
	}
}
