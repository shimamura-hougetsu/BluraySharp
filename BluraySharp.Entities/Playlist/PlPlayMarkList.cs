using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;

namespace BluraySharp.PlayList
{
	public class PlPlayMarkList : BdPart, IPlPlayMarkList
	{
		private byte[] value = new byte[0];

		[BdByteArrayField]
		private byte[] Value
		{
			get { return this.value; }
		}

		public override string ToString()
		{
			return "PlayMarkList";
		}

		public uint Length
		{
			get
			{
				return (uint)this.value.Length;
			}
			set
			{
				Array.Resize(ref this.value, (int) value);
			}
		}
	}
}
