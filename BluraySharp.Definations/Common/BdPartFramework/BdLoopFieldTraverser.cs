using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdLoopFieldTraverser : IBdFieldTraverser
	{
		private IBdList fieldList;
		private int fieldIndex;
		private IBdFieldVisitor rootField;

		public BdLoopFieldTraverser(IBdFieldVisitor rootField)
		{
			this.rootField = rootField;
			this.fieldList = this.rootField.Value as IBdList;

			this.fieldIndex = this.fieldList.Count;
		}

		public int Index
		{
			get { return this.fieldIndex; }
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

		IBdFieldVisitor IBdFieldVisitor.OffsetIndicator
		{
			get { return null; }
		}

		IBdFieldVisitor IBdFieldVisitor.LengthIndicator
		{
			get { return null; }
		}

		IBdFieldVisitor IBdFieldVisitor.SkipIndicator
		{
			get { return null; }
		}

		object IBdFieldVisitor.Value
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

		string IBdFieldInfo.Name
		{
			get
			{
				return string.Format("{0}[{1}]", this.rootField.Name, this.fieldIndex);
			}
		}

		Type IBdFieldInfo.Type
		{
			get { return this.rootField.Type; }
		}
		BdFieldAttribute IBdFieldInfo.Attribute
		{
			get { return this.rootField.Attribute; }
		}
	}
}
 