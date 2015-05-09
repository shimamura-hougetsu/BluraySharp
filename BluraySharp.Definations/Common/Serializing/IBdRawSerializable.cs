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


namespace BluraySharp.Common.Serializing
{
	/// <summary>
	/// Allows an object to be serialize to 
	/// or deserialized from a <see cref="IBdRawIoContext" />
	/// </summary>
	public interface IBdRawSerializable
	{
		/// <summary>
		/// Serialize this object as raw data into a serialization context
		/// </summary>
		/// <param name="context">Serialize context</param>
		/// <returns>Length of data written during serialization</returns>
		long SerializeTo(IBdRawWriteContext context);

		/// <summary>
		/// Fill this object with raw data from a deserialization context
		/// </summary>
		/// <param name="context">Deserialize context</param>
		/// <returns>Length of data used during deserialization</returns>
		long DeserializeFrom(IBdRawReadContext context);

		/// <summary>
		/// Update overall and get total length of this object.
		/// </summary>
		long RawLength { get; }
	}
}
