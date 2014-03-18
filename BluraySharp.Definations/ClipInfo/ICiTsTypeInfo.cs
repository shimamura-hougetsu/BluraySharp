
namespace BluraySharp.ClipInfo
{
	public interface ICiTsTypeInfo : BluraySharp.Common.IBdPart
	{
		byte ValidityFlags { get; set;}
		string FormatIdentifier { get; set; }
		string NetworkInformation { get; set; }
		string StreamFormatName { get; set; }
	}
}
