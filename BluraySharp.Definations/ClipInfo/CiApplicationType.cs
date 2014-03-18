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
