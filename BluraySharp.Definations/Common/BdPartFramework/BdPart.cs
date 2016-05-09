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

using BluraySharp.Common.Serializing;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BluraySharp.Common.BdPartFramework
{
	public abstract class BdPart : IBdPart
	{
		#region Static Shared Stuff

		private static IBdRawIoHelper<IBdFieldTraverser> ioHelp = BdIoHelperFactory.GetHelper<IBdFieldTraverser>();

		private static object lkSeekers = new object();
		private static Dictionary<Type, WeakReference> fieldSeekers = new Dictionary<Type, WeakReference>();
		
		private static ConstructorInfo GetFieldSeekerCtorNonSafe(Type thisType)
		{
			if (fieldSeekers.ContainsKey(thisType))
			{
				var wkRef = fieldSeekers[thisType];
				if (wkRef.IsAlive)
				{
					var seeker = wkRef.Target as ConstructorInfo;
					if (!seeker.IsNull())
					{
						return seeker;
					}
				}
			}

			return null;
		}

		private static ConstructorInfo GetFieldSeekerCtor(Type thisType)
		{
			var tCtor = GetFieldSeekerCtorNonSafe(thisType);

			if (tCtor.IsNull())
			{
				lock (lkSeekers)
				{
					tCtor = GetFieldSeekerCtorNonSafe(thisType);

					if (tCtor.IsNull())
					{
						Type tSeekerType = typeof(BdFieldTraverser<>).MakeGenericType(thisType);
						tCtor = tSeekerType.GetConstructor(new Type[] { thisType });

						fieldSeekers[thisType] = new WeakReference(tCtor);
					}
				}
			}
			
			return tCtor;
		}

		#endregion

		private IBdFieldTraverser fieldSeeker;
		
		public BdPart()
		{
			Type tThisType = this.GetType();
			var tCtor = BdPart.GetFieldSeekerCtor(tThisType);
			this.fieldSeeker = (IBdFieldTraverser) tCtor.Invoke(new object[] { this });
		}
		
		public long SerializeTo(IBdRawWriteContext context)
		{
			return BdPart.ioHelp.SerializeTo(this.fieldSeeker, context);
		}

		public long DeserializeFrom(IBdRawReadContext context)
		{
			return BdPart.ioHelp.DeserializeFrom(this.fieldSeeker, context);
		}

		public long RawLength
		{
			get
			{
				return BdPart.ioHelp.GetRawLength(this.fieldSeeker);
			}
		}

		public abstract override string ToString();
	}
}
