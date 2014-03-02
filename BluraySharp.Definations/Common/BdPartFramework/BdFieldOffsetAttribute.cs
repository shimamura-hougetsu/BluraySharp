﻿using System;

namespace BluraySharp.Common.BdPartFramework
{
	public class BdFieldOffsetAttribute : Attribute
	{
		public uint Offset { get; private set; }
		public string OffsetIndicator { get; private set; }

		public BdFieldOffsetAttribute(uint offset)
		{
			this.Offset = offset;
		}

		public BdFieldOffsetAttribute(string indicator)
		{
			this.OffsetIndicator = indicator;
		}
	}
}
