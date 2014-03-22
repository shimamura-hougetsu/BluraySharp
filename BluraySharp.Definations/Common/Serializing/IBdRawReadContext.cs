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
	public interface IBdRawReadContext : IBdRawIoContext
	{
		void Deserialize(IBdRawSerializable obj);

		void Deserialize(byte[] value);
		void Deserialize(byte[] value, int offset, int length);
		
		ulong Deserialize(BdIntSize intSize);

		string Deserialize(int byteCount, Encoding encoding);
	}
}
