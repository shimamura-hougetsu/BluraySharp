using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace BluraySharp.Architecture
{
	public abstract class BdPart<T> : IBdPart
		where T : BdPart<T>
	{
		private static BdPartFieldDescriptorSet descriptors = new BdPartFieldDescriptorSet(typeof(T));

		private BdPartFieldAccessor accessor;

		public BdPart()
		{
			this.accessor = new BdPartFieldAccessor(this, BdPart<T>.descriptors);
		}

		public long SerializeTo(IBdRawWriteContext context)
		{
			throw new NotImplementedException();
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			throw new NotImplementedException();
		}

		public long RawLength
		{
			get
			{
				return 0;
			}
		}

		private long Serialize(IBdRawReadContext context, BdPartFieldDescriptor filed)
		{
			throw new NotImplementedException();
		}

		private long Deserialize(IBdRawReadContext context, BdPartFieldDescriptor filed)
		{
			throw new NotImplementedException();
		}

		private long GetRawLength(BdPartFieldDescriptor filed)
		{
			throw new NotImplementedException();
		}

	}
}
