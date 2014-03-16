
using System.ComponentModel;
namespace BluraySharp.Common
{
	[TypeConverter(typeof(BdEnumConverter<BdConnectionCondition>))]
	public enum BdConnectionCondition : byte
	{
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		Unknown = 0x00,
		/// <summary>
		/// Not Seamless
		/// </summary>
		NotSeamless = 0x01,

		/// <summary>
		/// Seamless
		/// </summary>
		Seamless = 0x05,

		/// <summary>
		/// Seamless Concatenated
		/// </summary>
		SeamlessConcat = 0x06,
	}
}
