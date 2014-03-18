using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.Serializing
{
	public class BdRawIoTask : IBdRawIoTask
	{
		private object syncRoot = new object();
		public object SyncRoot
		{
			get { return this.syncRoot; }
		}
	}
}
