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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	public enum CiApplicationType : byte
	{
		Unknown = 0x00,
		
		MainTsMovie = 0x01,
		MainTsTimeBasedSlideShow,
		MainTsBrowsableSlideShow,

		SubTsBrowsableSlideShow = 0x04,
		SubTsIgMenu,
		SubTsTextST,
		SubTsStreamsPath,
		SubTsStereoscopicMovie,
		SubTsStereoscopicMenu,

		MainTsMovieAvchd = 0x0A,
	}
}
