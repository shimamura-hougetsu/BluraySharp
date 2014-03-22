/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

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

		public IBdFieldVisitor ScopeIndicator
		{
			get { return null; }
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
			get
			{
				Type[] tItemTypes = this.rootField.Type.GetGenericArguments();
				if (tItemTypes.Length != 1)
				{
					//TODO: Unexpected exception, fatal
					throw new ApplicationException();
				}
				return tItemTypes[0];
			}
		}

		BdFieldAttribute IBdFieldInfo.Attribute
		{
			get { return this.rootField.Attribute; }
		}
	}
}
 