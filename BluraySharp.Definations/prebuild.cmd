cd /d "%~dp0" || exit /B 233

set "REV=0"
for /f "tokens=1 delims=:" %%i in ('hg log -q -r .') do set "REV=%%i"

(
echo internal static partial class VersionInfo
echo {
echo  	public const string R = "%REV%";
echo }
) >".\Properties\~Revision.cs"
