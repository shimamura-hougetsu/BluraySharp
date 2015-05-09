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

using BluraySharp.Common;
using BluraySharp.Common.BdPartFramework;
using System;

namespace BluraySharp.PlayList
{
	public class PlStnSubPlayItemEntryInfo : BdPart, IPlStnSubPlayItemEntryInfo
	{
		[BdUIntField(BdIntSize.U8)]
		public byte SubPathId
		{
			get;
			set;
		}

		[BdUIntField(BdIntSize.U8)]
		public byte SubPlayItemId
		{
			get;
			set;
		}

		[BdUIntField(BdIntSize.U16)]
		public ushort StreamProgId
		{
			get;
			set;
		}

		private byte[] reservedForFutureUse = new byte[4];
		[BdByteArrayField]
		private byte[] ResersvedForFutureUse
		{
			get { return this.reservedForFutureUse; }
		}

		public override string ToString()
		{
			return "STN Entry refering a subplayitem";
		}
	}
}
