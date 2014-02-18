using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdPartFieldAccessor
	{
		private object thisObj;
		private BdPartFieldDescriptorSet fieldSet;

		public BdPartFieldAccessor(object thisObj, BdPartFieldDescriptorSet fieldSet)
		{
			this.thisObj = thisObj;
			this.fieldSet = fieldSet;
		}

		public object this[int index]
		{
			get
			{
				return this.fieldSet[index].Info.GetValue(this.thisObj);
			}
			set
			{
				this.fieldSet[index].Info.SetValue(this.thisObj, value);
			}
		}
	}
}
