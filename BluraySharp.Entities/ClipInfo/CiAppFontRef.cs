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

using BluraySharp.Common.BdPartFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.ClipInfo
{
	public class CiAppFontRef : BdPart, ICiAppFontRef
	{
		public Common.BdStandardPart.BdFontFileRef FontFileRef
		{
			get { throw new NotImplementedException(); }
		}

		public override string ToString()
		{
			throw new NotImplementedException();
		}
	}
}