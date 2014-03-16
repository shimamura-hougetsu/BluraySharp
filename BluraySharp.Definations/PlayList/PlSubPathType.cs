
using BluraySharp.Common;
using System.ComponentModel;
namespace BluraySharp.PlayList
{
	[System.ComponentModel.TypeConverter(typeof(BdEnumConverter<PlSubPathType>))]
	public enum PlSubPathType : byte
	{
		[System.ComponentModel.Browsable(false)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Unknown = 0x00,
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
