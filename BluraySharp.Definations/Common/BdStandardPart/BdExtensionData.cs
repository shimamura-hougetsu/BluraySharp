﻿using BluraySharp.Common.BdPartFramework;
using System;

namespace BluraySharp.Common.BdStandardPart
{
	[BdPartScope(BdIntSize.U32, IndicatorField = "LengthIndicator")]
	public class BdExtensionData : BdPart
	{
		private byte[] value = new byte[0];

		public uint LengthIndicator
		{
			get { return (uint)this.value.Length; }
			set { Array.Resize(ref this.value, (int) value); }
		}

		[BdByteArrayField]
		public byte[] Value
		{
			get { return this.value; }
			set { this.value = value; }
		}

		public override string ToString()
		{
			return "BdExtensionData";
		}
	}
}
