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

using BluraySharp.Common.Serializing;

namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdRawIoHelper<T>
	{
		long GetRawLength(T obj);

		long SerializeTo(T obj, IBdRawWriteContext context);

		long DeserializeFrom(T obj, IBdRawReadContext context);
	}

}
