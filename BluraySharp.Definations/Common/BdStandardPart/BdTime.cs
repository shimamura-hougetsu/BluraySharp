/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at BitBucket (https://bitbucket.org/subelf/bluraysharp)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.Serializing;
using System;

namespace BluraySharp.Common.BdStandardPart
{
	public class BdTime: BdPart
	{
		public BdTime() { }

		public BdTime(TimeSpan span)
		{
			this.AsSpan = span;
		}

		public BdTime(int hours, int minutes, int seconds, int milliseconds):
			this(new TimeSpan(0, hours, minutes, seconds, milliseconds))
		{
		}

		[BdUIntField(BdIntSize.U32)]
		public uint Value { get; set; }

		public TimeSpan AsSpan
		{
			get
			{
				return new TimeSpan(TimeValueToTicks(this.Value));
			}
			set
			{
				this.Value = TicksToTimeValue(value.Ticks);
			}
		}

		public uint AsFrameCount(BdViFrameRate frameRate)
		{
			return Convert.ToUInt32(frameRate.ToDouble() * this.AsSpan.TotalSeconds);
		}

		/// <summary>
		/// Get Non-Drop-Frame TimeCode
		/// </summary>
		/// <param name="frameRate">Frame rate</param>
		/// <returns>HH:MM:SS:FF</returns>
		public string ToNdfTimeCode(BdViFrameRate frameRate)
		{
			var tNdfFps = frameRate.ToInteger();
			var tFrames = Convert.ToInt32(this.AsFrameCount(frameRate));
			
			var tSec = tFrames / tNdfFps; tFrames %= tNdfFps;
			var tTime = new TimeSpan(0, 0, tSec);
			string tTimePart = tTime.ToString(@"hh\:mm\:ss");

			return string.Format("{0};{1:00.}", tTimePart, tFrames);
		}

		/// <summary>
		/// Get Drop-Frame TimeCode
		/// </summary>
		/// <param name="frameRate">Frame rate</param>
		/// <returns>HH:MM:SS;FF</returns>
		public string ToDfTimeCode(BdViFrameRate frameRate)
		{
			const int SecPerMin = 60;
			
			var tFDpM = 0;	//frames dropt per minute
			switch(frameRate)
			{
				case BdViFrameRate.Vi29:
					tFDpM = 2;
					break;
				case BdViFrameRate.Vi59:
					tFDpM = 4;
					break;
				default:
					//TODO
					//warning:("Drop-Frame-Timecode makes no sense other than Vi29 and Vi59");
					tFDpM = 0;
					break;
			}

			var tNdfFps = frameRate.ToInteger();
			var tFpM = tNdfFps * SecPerMin - tFDpM;	//Frames per minute
			var tFpDM = tFpM * 10 + tFDpM;	//Frame per dec-minute
			var tFrames = Convert.ToInt32(this.AsFrameCount(frameRate));

			var tDM = tFrames / tFpDM; tFrames = tFrames % tFpDM - tFDpM;
			var tM = tFrames / tFpM; tFrames = tFrames % tFpM + tFDpM;
			var tSec = tFrames / tNdfFps; tFrames %= tNdfFps;
			
			var tTime = new TimeSpan(0, tDM * 10 + tM, tSec);
			string tTimePart = tTime.ToString(@"hh\:mm\:ss");

			return string.Format("{0};{1:00.}", tTimePart, tFrames);
		}
		
		public override string ToString()
		{
			return this.AsSpan.ToString(@"hh\:mm\:ss\.fff");
		}

		public static long TimeValueToTicks(uint timeValue)
		{
			return timeValue * 2000L / 9;
		}

		public static uint TicksToTimeValue(long ticks)
		{
			var tValue = ticks * 9 / 1000;
			return (uint)((tValue + 1) >> 1);
		}
	}
}
