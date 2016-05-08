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

using BluraySharp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	[TypeConverter(typeof(BdEnumConverter<CiApplicationType>))]
	public enum CiApplicationType : byte
	{
		[Browsable(false)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
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
