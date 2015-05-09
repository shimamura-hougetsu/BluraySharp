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

using BluraySharp.Architecture;
using BluraySharp.Common;
using BluraySharp.Common.Serializing;
using BluraySharp.FileSystem;
using System;
using System.IO;

namespace BluraySharp
{
	public class BdmvContext
	{
		private static BdmvEntryRegistry entryRegistry = BdmvEntryRegistry.Instance;

		/// <summary>
		/// Create and return a BDMV entry object
		/// </summary>
		/// <typeparam name="T">BDMV entry type.</typeparam>
		/// <returns>Object created</returns>
		public T CreateEntry<T>() where T : class, IBdmvEntry
		{
			return entryRegistry.CreateEntry<T>();
		}

		/// <summary>
		/// Open a standalone BDMV file.
		/// </summary>
		/// <typeparam name="T">BDMV entry type.</typeparam>
		/// <param name="filePath">Full path of the target.</param>
		/// <returns>A BDMV entry loader/saver for the target file.</returns>
		public IBdfsEntryFile<T> OpenFile<T>(string filePath) where T : class, IBdmvEntry
		{
			return new BdfsStandaloneFile<T>(filePath);
		}

		/// <summary>
		/// Open a BDMV folder containing numbers of BDMV files.
		/// 
		/// Not implemented yet.
		/// </summary>
		/// <param name="directoryPath"></param>
		/// <returns></returns>
		public IBdfsRootFolder OpenFolder(string directoryPath)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Copy data from a BDMV entry to another
		/// </summary>
		/// <typeparam name="T">BDMV entry type.</typeparam>
		/// <param name="src">Copying source.</param>
		/// <param name="dest">Copying target.</param>
		public void Copy<T>(T src, T dest) where T : IBdPart
		{
			if (object.ReferenceEquals(dest, null))
			{
				throw new ArgumentNullException("dest");
			}

			if (!object.ReferenceEquals(src, null))
			{
				using (MemoryStream tMem = new MemoryStream())
				{
					IBdRawWriteContext tSerializer = new BdByteStreamWriteContext(tMem);
					tSerializer.Serialize(src);

					tMem.Position = 0;

					IBdRawReadContext tDeserializer = new BdByteStreamReadContext(tMem);
					tDeserializer.Deserialize(dest);
				}
			}
		}
	}
}
