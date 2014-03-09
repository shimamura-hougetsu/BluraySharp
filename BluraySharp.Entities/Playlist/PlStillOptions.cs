using System;
using BluraySharp.Architecture;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStillOptions : BdPart, IPlStillOptions
	{
		#region Private Data Fields

		private PlStillMode stillMode = PlStillMode.NotStill;
		private ushort stillDuration = 0;

		#endregion

		[BdUIntField(BdIntSize.U8)]
		public PlStillMode StillMode
		{
			get { return this.stillMode; }
			set { this.stillMode = value; }
		}
		[BdUIntField(BdIntSize.U16)]
		public ushort StillDuration
		{
			get { return this.stillDuration; }
			set { this.stillDuration = value; }
		}

		public override string ToString()
		{
			return "Still Info for PlayItem";
		}
	}
}
