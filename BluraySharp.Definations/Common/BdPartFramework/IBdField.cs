using System;
namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdField : IBdFieldDescription
	{
		object Value { get; set; }
	}
}
