
namespace BluraySharp.PlayList
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
		IgMenu = 0x03,

		/// <summary>
		/// Text Subtitle
		/// </summary>
		TextSub = 0x04,

		/// <summary>
		/// (Out of Mux) Synchronous Type of one or more Streams and PiP
		/// </summary>
		OoMSync = 0x05,

		/// <summary>
		/// (Out of Mux) Asynchronous Type of Pip
		/// </summary>
		OoMAsync = 0x06,

		/// <summary>
		/// (In Mux) Synchronous Type of PiP
		/// </summary>
		IMSync = 0x07,
	}
}
