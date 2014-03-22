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

using BluraySharp.Common;
using BluraySharp.Common.Serializing;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace BluraySharp.Architecture
{
	public class BdByteStreamWriteContext : BdByteStreamIoContext, IBdRawWriteContext
	{
		public BdByteStreamWriteContext(Stream stream)
			:base(stream)
		{}

		public void Serialize(byte[] buffer, int offset, int length)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("value");
			}

			this.Write(buffer, 0, length);
		}

		public void Serialize(IBdRawSerializable obj)
		{
			bool tIsNewTask = !this.InTask;

			if (tIsNewTask)
			{
				if (!this.StartTask())
				{
					//TODO: context is busy.
					throw new ApplicationException();
				}
				this.EnterScope(obj.RawLength);
			}
			else
			{
				this.EnterScope();
			}

			try
			{
				this.Position = obj.SerializeTo(this);
			}
			finally
			{
				this.ExitScope();

				if (tIsNewTask)
				{
					this.EndTask();
				}
			}
		}

		public void Serialize(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("value");
			}

			this.Write(buffer, 0, buffer.Length);
		}

		public void Serialize(ulong value, BdIntSize size)
		{
			const int tBufferSize = sizeof(ulong);
			int tSize = (int)size;

			byte[] tBuffer = BitConverter.GetBytes(value).Reverse().ToArray();
			this.Write(tBuffer, tBufferSize - tSize, tSize);
		}

		public override void Skip(long delta)
		{
			const int tBufferSize = 4096 * 16;
			byte[] tBuffer = new byte[tBufferSize];
			while (delta > 0)
			{
				int tLen = (int) Math.Min(tBufferSize, delta);
				base.Write(tBuffer, 0, tLen);
				delta -= tLen;
			}
		}

		public void Serialize(string value, int byteCount, Encoding encoding)
		{
			byte[] tStringBytes = encoding.GetBytes(value);
			(tStringBytes.Length > byteCount).AssertFalse();

			byte[] tBuffer = new byte[byteCount];
			tStringBytes.CopyTo(tBuffer, 0);

			this.Serialize(tBuffer);
		}
	}
}
