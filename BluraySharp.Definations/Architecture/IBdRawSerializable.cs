using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public interface IBdRawSerializable
	{
		/// <summary>
		/// Write serialized raw data of this object into a serialize context
		/// </summary>
		/// <param name="context">Serialize context</param>
		/// <returns>Length of data written during serialization</returns>
		long SerializeTo(IBdRawIoContext context);

		/// <summary>
		/// Create object with data from a deserialize context
		/// </summary>
		/// <param name="context">Deserialize context</param>
		/// <returns>Length of data used during deserialization</returns>
		long DeserializeFrom(IBdRawIoContext context);

		/// <summary>
		/// Total length of raw data.
		/// </summary>
		long RawLength { get; }
	}
}
