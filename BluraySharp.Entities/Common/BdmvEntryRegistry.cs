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

using BluraySharp.Common;
using System;
using System.Collections.Generic;

namespace BluraySharp.Common
{
	//Singleton
	public class BdmvEntryRegistry : IBdmvEntryRegistry
	{
		private delegate IBdmvEntry EntryCreator();

		private readonly Dictionary<string, EntryCreator> ctorTable = new Dictionary<string, EntryCreator>();

		private readonly Dictionary<string, BdmvEntryAttribute> attrTable = new Dictionary<string, BdmvEntryAttribute>();

		/// <summary>
		/// Create specified BDMV Entry
		/// </summary>
		/// <typeparam name="T">BDMV Entry Interface</typeparam>
		/// <returns>Created entry</returns>
		public T CreateEntry<T>() where T : class, IBdmvEntry
		{
			try
			{
				var tCreator = ctorTable[typeof(T).FullName];
				if (tCreator.IsNull())
				{
					throw new KeyNotFoundException();
				}

				return (T) tCreator();
			}
			catch (KeyNotFoundException)
			{
				//TODO: entry type not registered
				throw new ApplicationException();
			}
		}

		public BdmvEntryAttribute GetEntryAttribute<T>() where T : class, IBdmvEntry
		{
			try
			{
				var tAttr = attrTable[typeof(T).FullName];
				if (tAttr.IsNull())
				{
					throw new KeyNotFoundException();
				}

				return tAttr;
			}
			catch (KeyNotFoundException)
			{
				//TODO: entry type not registered
				throw new ApplicationException();
			}
		}

		private void RegisterArrayEntry<T, I>() 
			where T : I, new()
			where I : class, IBdmvArrayEntry
		{
			object[] tObj = typeof(T).GetCustomAttributes(typeof(BdmvArrayEntryAttribute), true);

			attrTable.Add(
					typeof(I).FullName, 
					typeof(I).GetCustomAttributes(typeof(BdmvArrayEntryAttribute), true)[0] as BdmvArrayEntryAttribute
				);
			ctorTable.Add(
					typeof(I).FullName,
					() => new T()
				);
		}

		private void RegisterTopEntry<T, I>()
			where T : I, new()
			where I : IBdmvTopEntry
		{
			attrTable.Add(
					typeof(I).FullName,
					typeof(T).GetCustomAttributes(typeof(BdmvTopEntryAttribute), true)[0] as BdmvTopEntryAttribute
				);
			ctorTable.Add(
					typeof(I).FullName,
					() => new T()
				);
		}

		private static BdmvEntryRegistry instance = new BdmvEntryRegistry();
		public static BdmvEntryRegistry Instance
		{
			get
			{
				return BdmvEntryRegistry.instance;
			}
		}

		private BdmvEntryRegistry()
		{
			this.RegisterArrayEntry<PlayList.BdMpls, PlayList.IBdMpls>();
			this.RegisterArrayEntry<ClipInfo.BdClpi, ClipInfo.IBdClpi>();
		}
	}
}
