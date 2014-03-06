using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;

namespace BluraySharp.PlayList
{
	public class PlPlayMarkList : BdPart, IPlPlayMarkList
	{
		private byte[] value = new byte[0];

		[BdUIntField(BdIntSize.U32)]
		public uint DataLen
		{
			get { return (uint)this.value.Length; }
			set { Array.Resize(ref this.value, (int)value); }
		}

		[BdByteArrayField]
		public byte[] Value
		{
			get { return this.value; }
			set { this.value = value; }
		}

		public override string ToString()
		{
			return "PlayMarkList";
		}
	}
}
