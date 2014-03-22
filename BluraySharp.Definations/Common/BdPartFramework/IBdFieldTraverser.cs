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

using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal interface IBdFieldTraverser : IBdFieldVisitor
	{
		int Index { get; set; }
		int LowerBound { get; }
		int UpperBound { get; }

		IBdFieldVisitor ScopeIndicator { get; }
	}
}
