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

namespace BluraySharp
{
	/// <summary>
	///Base of all exceptions defined in BluraySharp library.
	/// </summary>
	[Serializable]
	public abstract class BdException : ApplicationException
	{
	}

	/// <summary>
	/// Base of exceptions occurred during serializing or deserializng.
	/// </summary>
	[Serializable]
	public abstract class BdEntrySerializationException : BdException
	{
	}

	/// <summary>
	/// Base of exceptions occurred during editing bluray objects.
	/// </summary>
	[Serializable]
	public abstract class BdmvEntryAthoringException : BdException
	{
	}

	/// <summary>
	/// Base of exceptions occurred during operating on bluray filesystem items.
	/// </summary>
	[Serializable]
	public abstract class BdFileSystemException : BdException
	{
	}
}
