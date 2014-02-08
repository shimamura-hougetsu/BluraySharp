using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	//Singleton
	public class BdEntitiesRegistry : IBdEntitiesRegistry
	{
		private delegate IBdComponent ComponentCreator();
		private readonly Dictionary<string, ComponentCreator> comCtorTable = new Dictionary<string, ComponentCreator>();
		private readonly Dictionary<string, BdComponentAttribute> comAttrTable = new Dictionary<string, BdComponentAttribute>();

		private delegate IBdTopEntry TopEntryCreator();
		private readonly Dictionary<string, TopEntryCreator> teCtorTable = new Dictionary<string, TopEntryCreator>();
		private readonly Dictionary<string, BdTopEntryAttribute> teAttrTable = new Dictionary<string, BdTopEntryAttribute>();

		public T CreateComponent<T>() where T : IBdComponent
		{
			return (T)comCtorTable[typeof(T).FullName]();
		}

		public T CreateTopEntry<T>() where T : IBdTopEntry
		{
			return (T)teCtorTable[typeof(T).FullName]();
		}

		public BdComponentAttribute GetComponentAttribute<T>() where T : IBdComponent
		{
			return comAttrTable[typeof(T).FullName];
		}

		public BdTopEntryAttribute GetTopEntryAttribute<T>() where T : IBdTopEntry
		{
			return teAttrTable[typeof(T).FullName];
		}

		private void RegisterComponent<T, I>() 
			where T : I, new()
			where I : IBdComponent
		{
			comAttrTable.Add(
					typeof(I).FullName, 
					typeof(T).GetCustomAttributes(typeof(BdComponentAttribute), true)[0] as BdComponentAttribute
				);
			comCtorTable.Add(
					typeof(I).FullName,
					() => new T()
				);
		}

		private void RegisterTopEntry<T, I>()
			where T : I, new()
			where I : IBdTopEntry
		{
			teAttrTable.Add(
					typeof(I).FullName,
					typeof(T).GetCustomAttributes(typeof(BdTopEntryAttribute), true)[0] as BdTopEntryAttribute
				);
			teCtorTable.Add(
					typeof(I).FullName,
					() => new T()
				);
		}

		private static BdEntitiesRegistry instance = new BdEntitiesRegistry();
		public static BdEntitiesRegistry Instance
		{
			get
			{
				return instance;
			}
		}

		private BdEntitiesRegistry()
		{
			this.RegisterComponent<Playlist.PlayList, Playlist.IPlayList>();
		}
	}
}
