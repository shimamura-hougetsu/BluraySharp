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


namespace BluraySharp.FileSystem
{
	/// <summary>
	/// Bdmv Folder interface
	/// </summary>
	/// <typeparam name="T">Base type of files in this folder</typeparam>
	public interface IBdfsFolder<T> : IBdfsItem
		where T : IBdfsItem
	{
		T CreateFileContext(string name);
		IBdfsFolder<TT> CreateFolder<TT>(string name) where TT : IBdfsItem;
	}
}
