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

using System.Text;

namespace BluraySharp.Common.Serializing
{
	public interface IBdRawWriteContext : IBdRawIoContext
	{
		void Serialize(IBdRawSerializable obj);

		void Serialize(byte[] value, int offset, int length);
		void Serialize(byte[] value);

		void Serialize(ulong value, BdIntSize size);

		void Serialize(string value, int byteCount, Encoding encoding);
	}
}
