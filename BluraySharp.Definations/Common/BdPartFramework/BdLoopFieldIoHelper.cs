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

using BluraySharp.Common.Serializing;
using System;

namespace BluraySharp.Common.BdPartFramework
{
	internal class BdLoopFieldIoHelper : IBdRawIoHelper<IBdFieldVisitor>
	{
		private static BdLoopFieldIoHelper instance = new BdLoopFieldIoHelper();
		public static BdLoopFieldIoHelper Instance
		{
			get
			{
				return BdLoopFieldIoHelper.instance;
			}
		}

		private BdLoopFieldIoHelper() { }

		private void ValidateArg(IBdFieldVisitor obj)
		{
			if(obj.IsNull())
			{
				throw new ArgumentNullException("obj");
			}

			if (obj.Type.IsNull())
			{
				//TODO: Unknown field type
				throw new ArgumentException("obj");
			}

			if(obj.Type.GetInterface(typeof(IBdList).FullName) == null)
			{
				//TODO: accept IBdList fields only
				throw new ArgumentException("obj");
			}
		}

		private IBdRawIoHelper<IBdFieldTraverser> ioHelper =
			BdIoHelperFactory.GetHelper<IBdFieldTraverser>();

		public long GetRawLength(IBdFieldVisitor obj)
		{
			this.ValidateArg(obj);

			BdLoopFieldTraverser tSeeker = new BdLoopFieldTraverser(obj);
			return this.ioHelper.GetRawLength(tSeeker);
		}

		public long SerializeTo(IBdFieldVisitor obj, IBdRawWriteContext context)
		{
			this.ValidateArg(obj);

			BdLoopFieldTraverser tSeeker = new BdLoopFieldTraverser(obj);
			return this.ioHelper.SerializeTo(tSeeker, context);
		}

		public long DeserializeFrom(IBdFieldVisitor obj, IBdRawReadContext context)
		{
			this.ValidateArg(obj);
			
			BdLoopFieldTraverser tSeeker = new BdLoopFieldTraverser(obj);
			return this.ioHelper.DeserializeFrom(tSeeker, context);
		}
	}
}
