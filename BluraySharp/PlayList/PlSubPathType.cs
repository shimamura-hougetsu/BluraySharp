
namespace BluraySharp.Playlist
{
	public enum PlSubPathType : byte
	{
		/// <summary>
		/// Primary Audio for Browsable SlideShow
		/// </summary>
		PrAudio = 0x02,

		/// <summary>
		/// Interactive Graphic Menu
		/// </summary>
		IgMenu,

		/// <summary>
		/// Text Subtitle
		/// </summary>
		TextSub,

		/// <summary>
		/// (Out of Mux) Synchronous Type of one or more Streams and PiP
		/// </summary>
		OoMSync,

		/// <summary>
		/// (Out of Mux) Asynchronous Type of Pip
		/// </summary>
		OoMAsync,

		/// <summary>
		/// (In Mux) Synchronous Type of PiP
		/// </summary>
		IMSync,
	}
}
