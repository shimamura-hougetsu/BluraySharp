using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BluraySharp.Architecture
{
	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public class BdPartFieldAttribute : Attribute
	{
		public BdPartFieldType FieldType { get; private set; }

		public int ByteCount { get; private set; }
		public string ByteCountIndicator { get; private set; }

		public Encoding Encoding { get; private set; }
		public BdIntSize IntSize { get; private set; }

		public long Offset { get; set; }
		public string OffsetIndicator { get; set; }

		public int ElementCount { get; set; }
		public string ElementCountIndicator { get; set; }

		/// <summary>
		/// Indicating a Integer field.
		/// </summary>
		/// <param name="type">Must be UInt</param>
		/// <param name="intSize">Sepecify bytes occupied by this field</param>
		public BdPartFieldAttribute(BdPartFieldType type, BdIntSize intSize)
			: this()
		{
			if (type != BdPartFieldType.UInt)
			{
				//field type must be UInt.
				throw new ArgumentException("type");
			}

			this.FieldType = type;
			this.IntSize = intSize;
		}

		public BdPartFieldAttribute(BdPartFieldType type, int byteCount, Encoding encoding)
			: this()
		{
			if (type != BdPartFieldType.String)
			{
				//field type must be String.
				throw new ArgumentException("type");
			}

			this.FieldType = type;
			this.Encoding = encoding;
			this.ByteCount = byteCount;
		}

		public BdPartFieldAttribute(BdPartFieldType type, string byteCountIndicator, Encoding encoding)
			: this()
		{
			if (type != BdPartFieldType.String)
			{
				//field type must be String.
				throw new ArgumentException("type");
			}

			this.FieldType = type;
			this.Encoding = encoding;
			this.ByteCountIndicator = byteCountIndicator;
		}

		public BdPartFieldAttribute(BdPartFieldType type, int byteCount)
			: this()
		{
			if (type != BdPartFieldType.ByteArray)
			{
				//field type must be ByteArray.
				throw new ArgumentException("type");
			}

			this.FieldType = type;
			this.ByteCount = byteCount;
		}

		public BdPartFieldAttribute(BdPartFieldType type, string byteCountIndicator)
			: this()
		{
			if (type != BdPartFieldType.ByteArray)
			{
				//field type must be String.
				throw new ArgumentException("type");
			}

			this.FieldType = type;
			this.ByteCountIndicator = byteCountIndicator;
		}

		public BdPartFieldAttribute(BdPartFieldType type)
			: this()
		{
			if (type != BdPartFieldType.BdPart)
			{
				//field type must be BdPart.
				throw new ArgumentException("type");
			}

			FieldType = BdPartFieldType.BdPart;
		}

		private BdPartFieldAttribute()
		{
			ByteCount = -1;
			ByteCountIndicator = null;

			Encoding = null;

			IntSize = BdIntSize.Auto;

			Offset = -1;
			OffsetIndicator = null;

			ElementCount = -1;
			ElementCountIndicator = null;
		}
	}
}
