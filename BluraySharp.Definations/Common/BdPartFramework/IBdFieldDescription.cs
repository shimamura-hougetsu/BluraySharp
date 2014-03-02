using System;
namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdFieldDescription
	{
		BdFieldAttribute Attribute { get; }
		string Name { get; }
		Type Type { get; }
	}
}
