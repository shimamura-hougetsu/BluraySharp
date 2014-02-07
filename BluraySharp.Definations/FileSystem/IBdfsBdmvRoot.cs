using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.FileSystem
{
	public interface IBdfsBdmvRoot : IBdfsRootFolder
	{
		IBdfsComponentFolder<Playlist.IPlayList> Playlist { get; }

		IBdfsFolder<IBdfsItem> Clipinfo { get; }
		IBdfsFolder<IBdfsItem> Stream { get; }

		IBdfsItem Index { get; }
		IBdfsItem MovieObject { set; }
	}
}
