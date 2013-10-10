using System.Reflection;


[assembly: AssemblyVersion(VersionInfo.Value)]
[assembly: AssemblyFileVersion(VersionInfo.Value)]

internal static partial class VersionInfo
{
	private const string D = ".";

	private const string M = "0";
	private const string S = "0";
	private const string I = "1";

	public const string Value = M + D + S + D + I + D + R;
}
