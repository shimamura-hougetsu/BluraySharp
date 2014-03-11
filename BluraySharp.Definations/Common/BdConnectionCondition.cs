
namespace BluraySharp.Common
{
	public enum BdConnectionCondition : byte
	{
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
