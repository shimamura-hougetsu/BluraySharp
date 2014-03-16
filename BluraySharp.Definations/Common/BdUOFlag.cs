using System.ComponentModel;

namespace BluraySharp.Common
{
	[TypeConverter(typeof(BdEnumConverter<BdUOFlag>))]
	public enum BdUOFlag : byte
	{
		PipStChange = 0x1E,	//0x1E = 30
		//ReservedForPipStEnableDisable = 0x1F,


		SecondaryAudioChange = 0x20,
		SecondaryAudioEnableDisable,

		SecondaryVideoChange,
		SecondaryVideoEnableDisable,


		StChange = 0x24,
		StEnableDisable,


		PopupOff,
		PopupOn,


		AngleChange = 0x28,

		//ReservedForStChange = 0x29,

		PrimaryAudioChange = 0x3A,


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
		//ReservedForPauseOff = 0x36,
		PauseOn = 0x37,
		Stop,

		//ReservedForPlayFirstplay = 0x39,

		SkipToPrevPoint = 0x3A,
		SkipToNextPoint,
		TimeSearch,
		ChapterSearch,
		//ReservedForTitleSearch,
		//ReservedForMenuCall,	//0x3F=63
	}
}
