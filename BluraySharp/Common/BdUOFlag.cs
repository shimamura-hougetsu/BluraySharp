
namespace BluraySharp.Common
{
	public enum BdUOFlag : byte
	{
		PipPgChange = 0x1E,	//0x1E = 30
		Reserved1,
		SecondaryAudioChange,
		SecondaryAudioEnableDisable,
		SecondaryVideoChange,
		SecondaryVideoEnableDisable,
		PgChange,
		PgEnableDisable,
		PopupOff,
		PopupOn,
		AngleChange,
		Reserved2,
		PrimaryAudioChange,
		SelectAndActivate,
		Activate,
		Select,
		MoveRight,
		MoveLeft,
		MoveDown,
		MoveUp,
		Resume,
		Backward,
		Forward,
		Still,
		PauseOff,
		PauseOn,
		Stop,
		PlayFirstplay,
		SkipToPrevPoint,
		SkipToNextPoint,
		TimeSearch,
		ChapterSearch,
		TitleSearch,
		MenuCall,	//0x3F=63
	}
}
