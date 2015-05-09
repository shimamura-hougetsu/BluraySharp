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

using System;
using System.Collections;

namespace BluraySharp.Common
{
	public interface IBdList : ICollection, IEnumerable
	{
		object this[int index] { get; set; }
		int LowerBound { get; }
		int UpperBound { get; }

		int Capacity { get; }
	}
}
