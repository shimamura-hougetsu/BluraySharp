/* ****************************************************************************
 * 
 * BluraySharp
 * 
 * This is a C# library project aimed to parse or compose BDMV files.
 * 
 * Maintained at Google Code (https://code.google.com/p/bluray-sharp/)
 * Released under the terms of LGPL (http://www.gnu.org/licenses/lgpl.html).
 *
 * Mar. 2014, adm@subelf.net
 * 
 * ***************************************************************************/

using System;
using BluraySharp.Architecture;
using BluraySharp.Common.BdPartFramework;
using BluraySharp.Common;

namespace BluraySharp.PlayList
{
	public class PlStillOptions : BdPart, IPlStillOptions
	{
		#region StillMode

		private PlStillMode stillMode = PlStillMode.NotStill;

		[BdUIntField(BdIntSize.U8)]
		public PlStillMode StillMode
		{
			get { return this.stillMode; }
			set { this.stillMode = value; }
		}

		#endregion

		#region StillDuration

		private ushort stillDuration = 0;

		[BdUIntField(BdIntSize.U16)]
		public ushort StillDuration
		{
			get
			{
				return (ushort)(
					  this.StillMode == PlStillMode.StillForDuration ?
					  this.stillDuration :
					  0
				  );
			}
			set { this.stillDuration = value; }
		}

		#endregion

		public override string ToString()
		{
			return "Still Info for PlayItem";
		}
	}
}
