using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal class BdLoopFieldSeeker : IBdFieldSeeker
	{
		private IBdList fieldList;
		private int fieldIndex;
		private IBdField rootField;

		public BdLoopFieldSeeker(IBdField rootField)
		{
			this.rootField = rootField;
			this.fieldList = this.rootField.Value as IBdList;

			this.fieldIndex = this.fieldList.Count;
		}

		public int Index
		{
			get
			{ return this.fieldIndex; }
			set
			{
				if (value < this.fieldList.LowerBound || value >= this.fieldList.UpperBound)
				{
					throw new ArgumentOutOfRangeException("value");
				}

				this.fieldIndex = value;
			}
		}

		public int LowerBound
		{
			get
			{
				return this.fieldList.LowerBound;
			}
		}
		public int UpperBound
		{
			get
			{
				return this.fieldList.UpperBound;
			}
		}

		public string Name
		{
			get
			{
				return string.Format("{0}[{1}]", this.rootField.Name, this.fieldIndex);
			}
		}

		public Type Type
		{
			get
			{
				return this.rootField.Type;
			}
		}

		public BdFieldAttribute Attribute
		{
			get
			{
				return this.rootField.Attribute;
			}
		}

		public object Value
		{
			get
			{
				return this.fieldList[this.fieldIndex];
			}
			set
			{
				this.fieldList[this.fieldIndex] = value;
			}
		}


		public ulong Offset
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool IsOffsetSpecified
		{
			get
			{
				return false;
			}
		}
	}
}
 