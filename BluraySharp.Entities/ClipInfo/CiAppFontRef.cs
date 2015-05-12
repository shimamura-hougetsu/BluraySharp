﻿/* ****************************************************************************
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
using BluraySharp.Common.BdStandardPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	public class CiAppFontRef : BdPart, ICiAppFontRef
	{
		#region FontFileRef

		private BdFontFileRef fontFileRef = new BdFontFileRef();

		[BdSubPartField]
		public BdFontFileRef FontFileRef
		{
			get { return this.fontFileRef; }
		}

		[BdUIntField(BdIntSize.U8)]
		private byte ReservedForFutureUse { get; set; }

		#endregion

		public override string ToString()
		{
			return this.FontFileRef.ToString();
		}
	}
}
