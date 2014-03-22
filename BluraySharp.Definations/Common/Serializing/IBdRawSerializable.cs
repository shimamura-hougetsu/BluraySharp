/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/


namespace BluraySharp.Common.Serializing
{
	/// <summary>
	/// Defines interface can be serialize to 
	/// or deserialized from a <see cref="BluraySharp.Common.Serializing.IBdRawIoContext" />
	/// </summary>
	public interface IBdRawSerializable
	{
		/// <summary>
		/// Write serialized raw data of this object into a serialize context
		/// </summary>
		/// <param name="context">Serialize context</param>
		/// <returns>Length of data written during serialization</returns>
		long SerializeTo(IBdRawWriteContext context);

		/// <summary>
		/// Create object with data from a deserialize context
		/// </summary>
		/// <param name="context">Deserialize context</param>
		/// <returns>Length of data used during deserialization</returns>
		long DeserializeFrom(IBdRawReadContext context);

		/// <summary>
		/// Update and get total length of raw data.
		/// </summary>
		long RawLength { get; }
	}
}
