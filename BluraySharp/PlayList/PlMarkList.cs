using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public class PlMarkList : IBdRawSerializable
	{
		public long SerializeTo(BdRawSerializeContext context)
		{
			//throw new NotImplementedException();
			System.Diagnostics.Debug.Print("MarkList.Sz");
			return 0;
		}

		public long DeserializeFrom(BdRawSerializeContext context)
		{
			//throw new NotImplementedException();
			System.Diagnostics.Debug.Print("MarkList.Dz");
			return 0;
		}


		public long RawLength
		{
			get { throw new NotImplementedException(); }
		}
	}
}
