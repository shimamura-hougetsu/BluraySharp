using BluraySharp.Common;
using System.Collections.Generic;

namespace BluraySharp.FileSystem
{
	//Singleton
	public class BdfsEntryRegistry : IBdfsEntryRegistry
	{
		private delegate IBdmvEntry EntryCreator();

		private readonly Dictionary<string, EntryCreator> ctorTable = new Dictionary<string, EntryCreator>();

		private readonly Dictionary<string, BdmvEntryAttribute> attrTable = new Dictionary<string, BdmvEntryAttribute>();

		public T CreateEntry<T>() where T : IBdmvEntry
		{
			return (T) ctorTable[typeof(T).FullName]();
		}

		public BdmvEntryAttribute GetEntryAttribute<T>() where T : IBdmvEntry
		{
			return attrTable[typeof(T).FullName];
		}

		private void RegisterArrayEntry<T, I>() 
			where T : I, new()
			where I : IBdmvArrayEntry
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

		private static BdfsEntryRegistry instance = new BdfsEntryRegistry();
		public static BdfsEntryRegistry Instance
		{
			get
			{
				return BdfsEntryRegistry.instance;
			}
		}

		private BdfsEntryRegistry()
		{
			this.RegisterArrayEntry<PlayList.BdMpls, PlayList.IBdMpls>();
		}
	}
}
