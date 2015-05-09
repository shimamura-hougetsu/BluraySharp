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

using System.Collections;
using System.Collections.Generic;

namespace BluraySharp.Common
{
	public interface IBdList<T> : IBdList, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		T CreateNew();

		new T this[int index] { get; set; }

		new int Count { get; }

		void Insert(int index, T item);

		void RemoveAt(int index);

		int IndexOf(T item);
	}
}
