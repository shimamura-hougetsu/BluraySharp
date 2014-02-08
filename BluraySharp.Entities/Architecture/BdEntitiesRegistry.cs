﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	//Singleton
	public class BdEntitiesRegistry : IBdEntitiesRegistry
	{
		private delegate IBdComponentEntry ComponentCreator();
		private readonly Dictionary<string, ComponentCreator> ctorTable = new Dictionary<string, ComponentCreator>();

		private readonly Dictionary<string, BdComponentEntryAttribute> attrTable = new Dictionary<string, BdComponentEntryAttribute>();

		public T CreateEntry<T>() where T : IBdComponentEntry
		{
			return (T) ctorTable[typeof(T).FullName]();
		}

		public BdComponentEntryAttribute GetEntryAttribute<T>() where T : IBdComponentEntry
		{
			return attrTable[typeof(T).FullName];
		}

		private void RegisterArrayEntry<T, I>() 
			where T : I, new()
			where I : IBdArrayEntry
		{
			attrTable.Add(
					typeof(I).FullName, 
					typeof(T).GetCustomAttributes(typeof(BdArrayEntryAttribute), true)[0] as BdArrayEntryAttribute
				);
			ctorTable.Add(
					typeof(I).FullName,
					() => new T()
				);
		}

		private void RegisterTopEntry<T, I>()
			where T : I, new()
			where I : IBdTopEntry
		{
			attrTable.Add(
					typeof(I).FullName,
					typeof(T).GetCustomAttributes(typeof(BdTopEntryAttribute), true)[0] as BdTopEntryAttribute
				);
			ctorTable.Add(
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
			this.RegisterArrayEntry<Playlist.PlayList, Playlist.IPlayList>();
		}
	}
}
