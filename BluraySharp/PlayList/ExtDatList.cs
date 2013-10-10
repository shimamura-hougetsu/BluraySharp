using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class ExtDatList : IBdRawSerializable
	{
		public long SerializeTo(BdRawSerializeContext context)
		{
			//throw new NotImplementedException();
			System.Diagnostics.Debug.Print("ExtDatList.Sz");
			return 0;
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			//throw new NotImplementedException();
			System.Diagnostics.Debug.Print("ExtDatList.Dz");
			return 0;
		}


		public long Length
		{
			get { throw new NotImplementedException(); }
		}
	}
}
