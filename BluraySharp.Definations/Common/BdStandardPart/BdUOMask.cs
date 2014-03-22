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

using BluraySharp.Common.Serializing;

namespace BluraySharp.Common.BdStandardPart
{
	/// <summary>
	/// Defined BDMV user operation forbidding mask bits
	/// </summary>
	public class BdUOMask : IBdPart
	{
		private BdBitwise64 value = new BdBitwise64();

		/// <summary>
		/// Get or Set an unsigned long value containing all mask bits
		/// </summary>
		public ulong Value
		{
			get { return this.value.Value; }
			set { this.value.Value = value; }
		}

		/// <summary>
		/// Get or Set mask bit sepecified by <see cref="BdUOFlag"/>
		/// </summary>
		/// <param name="index">User operation type.</param>
		/// <returns>True for forbidden, and false for permit.</returns>
		public bool this[BdUOFlag index]
		{
			get
			{
				return this.value[(byte)index, 1] == 1;
			}
			set
			{
				this.value[(byte)index, 1] = (value ? 1u : 0u);
			}
		}

		/// <summary>
		/// Serializes this object to a <see cref="IBdRawWriteContext"/>.
		/// </summary>
		/// <param name="context">Target context of serialization</param>
		/// <returns>Count of total bytes written</returns>
		public long SerializeTo(IBdRawWriteContext context)
		{
			context.Serialize(this.value);

			return context.Position;
		}

		/// <summary>
		/// Deserialize data from a <see cref="IBdRawReadContext"/> into this object.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public long DeserializeFrom(IBdRawReadContext context)
		{
			this.value = new BdBitwise64();
			context.Deserialize(this.value);

			return context.Position;
		}

		/// <summary>
		/// Update overall and get total length of this object
		/// </summary>
		public long RawLength
		{
			get
			{
				return this.value.RawLength;
			}
		}
	}
}
