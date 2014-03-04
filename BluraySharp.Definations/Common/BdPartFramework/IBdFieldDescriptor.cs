using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdFieldDescriptor : IBdFieldInfo
	{
		void SetValue(object thisObj, object value);
		object GetValue(object thisObj);
	}
}
