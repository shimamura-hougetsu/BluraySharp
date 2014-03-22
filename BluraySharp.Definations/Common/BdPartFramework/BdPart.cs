﻿/* ****************************************************************************
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
using System.Reflection;

namespace BluraySharp.Common.BdPartFramework
{
	public abstract class BdPart : IBdPart
	{
		private static IBdRawIoHelper<IBdFieldTraverser> ioHelp = BdPart.InitializeIoHelpers();

		private IBdFieldTraverser fieldSeeker;

		private static IBdRawIoHelper<IBdFieldTraverser> InitializeIoHelpers()
		{
			BdIoHelperFactory.RegisterHelper(BdFieldIoHelper.Instance);
			BdIoHelperFactory.RegisterHelper(BdFieldTraverserIoHelper.Instance);

			return BdIoHelperFactory.GetHelper<IBdFieldTraverser>();
		}

		public BdPart()
		{
			Type tThisType = this.GetType();
			Type tSeekerType = typeof(BdFieldTraverser<>).MakeGenericType(tThisType);
			ConstructorInfo tCtor = tSeekerType.GetConstructor(new Type[] { tThisType });
			this.fieldSeeker = (IBdFieldTraverser)tCtor.Invoke(new object[] { this });
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
