using System;
namespace BluraySharp.Common.BdPartRawIoHelper
{
	internal interface IBdField : IBdFieldDescription
	{
		object Value { get; set; }
	}
}
