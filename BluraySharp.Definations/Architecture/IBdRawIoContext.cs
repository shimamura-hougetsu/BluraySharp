﻿using System;
namespace BluraySharp.Architecture
{
	public interface IBdRawIoContext
	{
		void EnterScope();
		void ExitScope(long length);
	
		void EnterScope(long length);
		void ExitScope();

		long Length { get; }
		long Position { get; set; }
	}
}
