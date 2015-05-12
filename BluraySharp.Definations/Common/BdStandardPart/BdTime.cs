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

		public BdTime(int hours, int minutes, int seconds, int milliseconds)
		{
			this.AsSpan = new TimeSpan(0, hours, minutes, seconds, milliseconds);
		}

		[BdUIntField(BdIntSize.U32)]
		public uint Value { get; set; }

		public TimeSpan AsSpan
		{
			get
			{
				return new TimeSpan(this.Value * 2000L / 9);
			}
			set
			{
				this.Value = (uint)(value.Ticks * 9 / 2000);
			}
		}

		public uint AsFrameCount(BdViFrameRate frameRate)
		{
			return Convert.ToUInt32(frameRate.ToDouble() * this.AsSpan.TotalSeconds);
		}

		/// <summary>
		/// Get Non-Drop-Frame TimeCode for 
		/// </summary>
		/// <param name="frameRate">Frame rate</param>
		/// <returns>HH:MM:SS:FF</returns>
		public string AsNdfTimeCode(BdViFrameRate frameRate)
		{
			var tFrames = Convert.ToInt32(this.AsFrameCount(frameRate));
			var tNdfRate = frameRate.ToInteger();
			var tTime = new TimeSpan(0, 0, tFrames / tNdfRate);
			string tTimePart = tTime.ToString(@"hh\:mm\:ss");
			var tFramePart = tFrames % tNdfRate;

			return string.Format("{0}:{1:00.}", tTimePart, tFramePart);
		}

		public override string ToString()
		{
			return this.AsSpan.ToString();
		}
	}
}
