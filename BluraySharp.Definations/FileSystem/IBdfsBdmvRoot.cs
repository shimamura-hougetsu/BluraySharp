using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.TopEntry;

namespace BluraySharp.FileSystem
{
	public interface IBdfsBdmvRoot : IBdfsRootFolder
	{
		IBdfsArrayComponentFolder<PlayList.IPlayList> PlayList { get; }
		IBdfsArrayComponentFolder<ClipInfo.IClipInfo> ClipInfo { get; }
		IBdfsArrayComponentFolder<JavaObject.IBdJavaObject> JavaObject { get; }

		IBdfsTopEntryFile<IBdIndex> Index { get; }
		IBdfsTopEntryFile<IBdMovieObject> MovieObject { get; }
	}
}
