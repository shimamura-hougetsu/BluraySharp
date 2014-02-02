using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BluraySharp.Common
{
	public class BdComponentAttribute : Attribute
	{
		private bool requireBackup;

		private string pathPattern;

		public string PathPattern
		{
			get { return pathPattern; }
			set { pathPattern = value; }
		}
		
		private int maxSerialNumber;

		public int MaxSerialNumber
		{
			get { return maxSerialNumber; }
			set { maxSerialNumber = value; }
		}

		private string namePattern;

		public string NamePattern
		{
			get { return namePattern; }
			set { namePattern = value; }
		}

		public bool RequireBackup
		{
			get { return requireBackup; }
			set { requireBackup = value; }
		}

		public BdComponentAttribute(string pathPattern, string namePattern, int maxSerialNumber, bool requireBackup)
		{
			this.pathPattern = pathPattern;
			this.namePattern = namePattern;
			this.maxSerialNumber = maxSerialNumber;
			this.requireBackup = requireBackup;
		}
	}
}
