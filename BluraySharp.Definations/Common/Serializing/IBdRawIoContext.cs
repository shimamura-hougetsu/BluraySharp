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

namespace BluraySharp.Common.Serializing
{
	public interface IBdRawIoContext
	{
		bool StartTask();
		void EndTask();
		bool InTask { get; }

		void EnterScope();
		void ExitScope(long length);
	
		void EnterScope(long length);
		void ExitScope();

		long Length { get; }
		long Position { get; set; }
	}
}
