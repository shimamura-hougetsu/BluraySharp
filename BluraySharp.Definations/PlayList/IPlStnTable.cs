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

using BluraySharp.Common;
using BluraySharp.Common.Serializing;

namespace BluraySharp.PlayList
{
	public interface IPlStnTable : IBdPart
	{
		IBdList<IPlStnViEntry> ViEntries { get; }
		IBdList<IPlStnAuEntry> AuEntries { get; }
		IBdList<IPlStnStEntry> StEntries { get; }
		IBdList<IPlStnIgEntry> IgEntries { get; }
		IBdList<IPlStnSaEntry> SaEntries { get; }
		IBdList<IPlStnSvEntry> SvEntries { get; }
		IBdList<IPlStnStEntry> PipStEntries { get; }
	}
}
