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
		/// <typeparam name="T">BDMV entry type</typeparam>
		/// <returns>Object created</returns>
		public T CreateEntry<T>() where T : class, IBdmvEntry
		{
			return entryRegistry.CreateEntry<T>();
		}

		public IBdfsEntryFile<T> OpenFile<T>(string filePath) where T : class, IBdmvEntry
		{
			return new BdfsStandaloneFile<T>(filePath);
		}

		public IBdfsRootFolder OpenFolder(string directoryPath)
		{
			throw new NotImplementedException();
		}

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
