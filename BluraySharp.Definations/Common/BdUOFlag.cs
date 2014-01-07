
namespace BluraySharp.Common
{
	public enum BdUOFlag : byte
	{
		PipPgChange = 0x1E,	//0x1E = 30
		ReservedForPipPgEnableDisable,

		SecondaryAudioChange,
		SecondaryAudioEnableDisable,

		SecondaryVideoChange,
		SecondaryVideoEnableDisable,

		PgChange,
		PgEnableDisable,

		PopupOff,
		PopupOn,

		AngleChange,
		ReservedForPgChange,
		PrimaryAudioChange,

		SelectAndActivateButton,
		ActivateButton,
		SelectButton,
		MoveRightSelectedButton,
		MoveLeftSelectedButton,
		MoveDownSelectedButton,
		MoveUpSelectedButton,

		Resume,
		BackwardPlay,
		ForwardPlay,
		Still,
		ReservedForPauseOff,
		PauseOn,
		Stop,
		ReservedForPlayFirstplay,
		SkipToPrevPoint,
		SkipToNextPoint,
		TimeSearch,
		ChapterSearch,
		ReservedForTitleSearch,
		ReservedForMenuCall,	//0x3F=63
	}
}
