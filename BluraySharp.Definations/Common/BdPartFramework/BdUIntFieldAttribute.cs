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


namespace BluraySharp.Common.BdPartFramework
{
	internal class BdUIntFieldAttribute : BdFieldAttribute
	{
		public BdIntSize Size { get; private set; }
		public BdUIntFieldAttribute(BdIntSize size)
			:base(BdFieldType.UInt)
		{
			this.Size = size;
		}
	}
}
