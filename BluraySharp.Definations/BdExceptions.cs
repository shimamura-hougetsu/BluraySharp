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

namespace BluraySharp
{
	[Serializable]
	public class BdException : ApplicationException
	{
	}

	[Serializable]
	public class BdEntrySerializationException : BdException
	{
	}

	[Serializable]
	public class BdmvEntryComposingException : BdException
	{
	}

	[Serializable]
	public class BdFileSystemException : BdException
	{
	}
}
