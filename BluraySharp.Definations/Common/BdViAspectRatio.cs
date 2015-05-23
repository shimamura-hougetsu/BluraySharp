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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	[TypeConverter(typeof(BdEnumConverter<BdUOFlag>))]
	public enum BdViAspectRatio
	{
		Unknown = 0x0,

		Vi4to3= 0x02,
		Vi16to9 = 0x03,
	}
}
