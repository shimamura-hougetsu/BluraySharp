
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
