using System;
namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdFieldInfo
	{
		BdFieldAttribute Attribute { get; }
		string Name { get; }
		Type Type { get; }
	}
}
