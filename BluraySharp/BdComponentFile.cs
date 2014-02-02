
namespace BluraySharp
{
	public class BdmvComponentFile<T> where T : IBdComponent
	{
		private int number;

		public int Number
		{
			get { return number; }
			set { number = value; }
		}

		private Language langCode;

		public Language LangCode
		{
			get { return langCode; }
			set { langCode = value; }
		}
		
	}
}
