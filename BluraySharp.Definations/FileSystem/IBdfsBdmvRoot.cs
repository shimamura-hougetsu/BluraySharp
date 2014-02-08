using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.TopEntry;

namespace BluraySharp.FileSystem
{
	public interface IBdfsBdmvRoot : IBdfsRootFolder
	{
		IBdfsComponentFolder<Playlist.IPlayList> PlayList { get; }
		IBdfsComponentFolder<ClipInfo.IClipInfo> ClipInfo { get; }
		IBdfsComponentFolder<JavaObject.IBdJavaObject> JavaObject { get; }

		IBdfsTopEntryFile<IBdIndex> Index { get; }
		IBdfsTopEntryFile<IBdMovieObject> MovieObject { get; }
	}
}
