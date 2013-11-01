using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.PlayList
{
	public enum UOFlag : byte
	{
		 MenuCall = 0,
		 TitleSearch,
		 ChapterSearch ,
		 TimeSearch ,
		 SkipToNextPoint ,
		 SkipToPrevPoint ,
		 PlayFirstplay ,
		 Stop ,
		 PauseOn ,
		 PauseOff ,
		 Still ,
		 Forward ,
		 Backward ,
		 Resume ,
		 MoveUp ,
		 MoveDown ,
		 MoveLeft ,
		 MoveRight ,
		 Select ,
		 Activate ,
		 SelectAndActivate ,
		 PrimaryAudioChange ,
		 Reserved1,
		 AngleChange ,
		 PopupOn ,
		 PopupOff ,
		 PgEnableDisable ,
		 PgChange ,
		 SecondaryVideoEnableDisable ,
		 SecondaryVideoChange ,
		 SecondaryAudioEnableDisable ,
		 SecondaryAudioChange ,
		 Reserved2,
		 PipPgChange,
	}
}
