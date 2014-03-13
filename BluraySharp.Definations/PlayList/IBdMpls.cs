using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	[BdmvArrayEntry("PLAYLIST", "mpls", 2000, true)]
	public interface IBdMpls: IBdmvArrayEntry
	{
		string MplsMark { get; }
		string MplsVer { get; set; }

		BluraySharp.PlayList.IPlAppInfo AppInfo { get; }
		BluraySharp.PlayList.IPlPlayItemList PlayItemList { get; }
		BluraySharp.PlayList.IPlPlayMarkList PlayMarkList { get; }
		BluraySharp.Common.BdStandardPart.BdExtensionData ExtensionData { get; set; }
	}
}
