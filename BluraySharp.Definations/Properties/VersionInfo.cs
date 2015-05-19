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

using System.Reflection;

[assembly: AssemblyVersion(VersionInfo.Value)]
[assembly: AssemblyFileVersion(VersionInfo.Value)]

internal static partial class VersionInfo
{
	private const string D = ".";

	private const string M = "0";
	private const string S = "3";
	private const string I = "3";

	public const string Value = M + D + S + D + I + D + R;
}