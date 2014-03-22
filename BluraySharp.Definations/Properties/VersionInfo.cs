/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
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
	private const string S = "2";
	private const string I = "2";

	public const string Value = M + D + S + D + I + D + R;
}