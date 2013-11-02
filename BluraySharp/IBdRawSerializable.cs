
namespace BluraySharp
{
	public interface IBdRawSerializable
	{
		/// <summary>
		/// Write serialized raw data of this object into a serialize context
		/// </summary>
		/// <param name="context">Serialize context</param>
		/// <returns>Length of data written during serialization</returns>
		long SerializeTo(BdRawSerializeContext context);

		/// <summary>
		/// Create object with data from a deserialize context
		/// </summary>
		/// <param name="context">Deserialize context</param>
		/// <returns>Length of data used during deserialization</returns>
		long DeserializeFrom(BdRawSerializeContext context);

		/// <summary>
		/// Total length of raw data.
		/// </summary>
		long RawLength { get; }
	}
}
