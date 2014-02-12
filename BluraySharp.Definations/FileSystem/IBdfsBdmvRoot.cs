using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluraySharp.TopEntry;

namespace BluraySharp.FileSystem
{
	public interface IBdfsBdmvRoot : IBdfsRootFolder
	{
		IBdfsArrayEntryFolder<PlayList.IPlayList> PlayList { get; }
		IBdfsArrayEntryFolder<ClipInfo.IClipInfo> ClipInfo { get; }
		IBdfsArrayEntryFolder<JavaObject.IBdJavaObject> JavaObject { get; }

		IBdfsTopEntryFile<IBdIndex> Index { get; }
		IBdfsTopEntryFile<IBdMovieObject> MovieObject { get; }
	}
}
