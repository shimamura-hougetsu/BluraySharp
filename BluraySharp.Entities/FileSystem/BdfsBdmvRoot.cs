
namespace BluraySharp.FileSystem
{
	public class BdfsBdmvRoot: BdfsRootFolder, IBdfsBdmvRoot
	{
		public override System.Collections.Generic.IEnumerable<System.Exception> Validate()
		{
			throw new System.NotImplementedException();
		}

		public IBdfsArrayEntryFolder<Playlist.IPlayList> PlayList
		{
			get;
			private set;
		}

		public IBdfsArrayEntryFolder<ClipInfo.IClipInfo> ClipInfo
		{
			get;
			private set;
		}

		public IBdfsArrayEntryFolder<JavaObject.IBdJavaObject> JavaObject
		{
			get;
			private set;
		}

		public IBdfsTopEntryFile<TopEntry.IBdIndex> Index
		{
			get;
			private set;
		}

		public IBdfsTopEntryFile<TopEntry.IBdMovieObject> MovieObject
		{
			get;
			private set;
		}

		public override System.Collections.Generic.IEnumerable<IBdfsItem> Children
		{
			get
			{
				yield return this.ClipInfo;
				yield return this.PlayList;
				yield return this.JavaObject;
				foreach (IBdfsItem iItem in this.children)
				{
					yield return iItem;
				}

				yield return this.Index;
				yield return this.MovieObject;
			}
		}

		public BdfsBdmvRoot()
		{
			this.ClipInfo = new BdfsArrayEntryFolder<ClipInfo.IClipInfo>(this);
			this.PlayList = new BdfsArrayEntryFolder<Playlist.IPlayList>(this);
			this.JavaObject = new BdfsArrayEntryFolder<JavaObject.IBdJavaObject>(this);

			this.Index = new BdfsTopEntryFile<TopEntry.IBdIndex>(this);
			this.MovieObject = new BdfsTopEntryFile<TopEntry.IBdMovieObject>(this); ;
		}
	}
}
