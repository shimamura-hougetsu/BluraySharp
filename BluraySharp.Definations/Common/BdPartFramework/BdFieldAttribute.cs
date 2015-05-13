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

namespace BluraySharp.Common.BdPartFramework
{
	[AttributeUsage(AttributeTargets.Property, Inherited=true, AllowMultiple=false)]
	internal abstract class BdFieldAttribute : Attribute
	{
		public BdFieldType FieldType { get; private set; }

		public string OffsetIndicator { get; set; }
		public string LengthIndicator { get; set; }
		public string SkipIndicator { get; set; }

		/// <summary>
		/// Field will be ignored if length of the left data in scope is below OptionalLength
		/// </summary>
		public uint OptionalLength { get; set; }

		public BdFieldAttribute(BdFieldType type)
		{
			this.FieldType = type;
		}
	}
}
