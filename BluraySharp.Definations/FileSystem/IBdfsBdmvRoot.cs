using BluraySharp.TopEntry;

namespace BluraySharp.FileSystem
{
	public interface IBdfsBdmvRoot : IBdfsRootFolder
	{
		IBdfsArrayEntryFolder<PlayList.IBdMpls> PlayList { get; }
		IBdfsArrayEntryFolder<ClipInfo.IClipInfo> ClipInfo { get; }
		IBdfsArrayEntryFolder<JavaObject.IBdJavaObject> JavaObject { get; }

		IBdfsTopEntryFile<IBdIndex> Index { get; }
		IBdfsTopEntryFile<IBdMovieObject> MovieObject { get; }
	}
}
