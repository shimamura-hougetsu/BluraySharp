using System;
namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal interface IBdFieldDescription
	{
		BdFieldAttribute Attribute { get; }
		string Name { get; }
		Type Type { get; }
	}
}
