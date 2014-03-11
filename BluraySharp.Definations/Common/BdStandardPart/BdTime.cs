﻿using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common.Serializing;
using System;


namespace BluraySharp.Common.BdStandardPart
{
	public class BdTime: BdPart
	{
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
			TimeSpan tTime = this.AsSpan;
			string tTimePart = tTime.ToString(@"hh\:mm\:ss");
			double tFramePart = tTime.Milliseconds * Math.Ceiling(frameRate.ToDouble()) / 1000.0;

			return string.Format("{0}:{1:00.}", tTimePart, tFramePart);
		}

		public override string ToString()
		{
			return this.AsSpan.ToString();
		}
	}
}