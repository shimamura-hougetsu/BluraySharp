using System.ComponentModel;

namespace BluraySharp.Common
{
	[TypeConverter(typeof(BdEnumConverter<BdUOFlag>))]
	public enum BdUOFlag : byte
	{
		PipStChange = 0x1E,	//0x1E = 30
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		ReservedForPipStEnableDisable,


		SecondaryAudioChange = 0x20,
		SecondaryAudioEnableDisable,

		SecondaryVideoChange,
		SecondaryVideoEnableDisable,


		StChange = 0x24,
		StEnableDisable,


		PopupOff,
		PopupOn,


		AngleChange = 0x28,
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		ReservedForStChange,
		PrimaryAudioChange,


		SelectButtonAndActivate = 0x2B,
		ActivateButton,
		SelectButton,
		MoveRightSelectedButton,
		MoveLeftSelectedButton,
		MoveDownSelectedButton,
		MoveUpSelectedButton,


		Resume = 0x32,

		BackwardPlay,
		ForwardPlay,

		StillOff,
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		ReservedForPauseOff = 0x36,
		PauseOn = 0x37,
		Stop,
		
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		ReservedForPlayFirstplay = 0x39,

		SkipToPrevPoint = 0x3A,
		SkipToNextPoint,
		TimeSearch,
		ChapterSearch,
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		ReservedForTitleSearch,
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		ReservedForMenuCall,	//0x3F=63
	}
}
