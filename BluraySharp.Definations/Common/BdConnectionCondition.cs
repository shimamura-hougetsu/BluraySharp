/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

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
