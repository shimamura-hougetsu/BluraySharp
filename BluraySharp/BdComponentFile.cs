
using System.IO;
using System;

namespace BluraySharp
{
	public class BdmvComponentFile<T> where T : IBdComponent, new()
	{
		private int number;

		public int Number
		{
			get { return number; }
			set { number = value; }
		}

		private BdLang lang;

		public BdLang Lang
		{
			get { return lang; }
			set { lang = value; }
		}

		void Load()
		{
			throw new NotImplementedException();
		}

		void Save()
		{
			throw new NotImplementedException();
		}
	}
}
