cd /d "%~dp0" || exit /B 233

set "REV=0"
for /f "tokens=1,*" %%i in ('hg log -r .') do if "%%i"=="changeset:" for /f "tokens=1 delims=:" %%i in ("%%j") do set

(
echo internal static partial class VersionInfo
echo {
echo  	public const string R = "%REV%";
echo }
) >".\Properties\~Revision.cs"
