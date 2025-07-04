using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace WriterSharp.PluginApi.Ini
{

	public unsafe class IniParser
	{

		readonly Dictionary<string, Dictionary<string, string>> sections;
		byte* fileBuffer;
		long fileSize;

		public IniParser()
		{

			sections = new(StringComparer.OrdinalIgnoreCase);

		}

		public void Parse(char* filepath)
		{

			ushort allocAmount = 4096;

			string? marshalledPtr = Marshal.PtrToStringAuto((nint)filepath);

			if (!File.Exists(marshalledPtr))
				throw new FileNotFoundException("INI file not found.");

			fileSize = new FileInfo(marshalledPtr).Length;
			fileBuffer = (byte*)NativeMemory.Alloc((nuint)fileSize);

			using (var stream = new FileStream(marshalledPtr, FileMode.Open, FileAccess.Read, FileShare.Read))
			{

				// fixed (byte* buffer = stackalloc byte[4096])
				fixed (byte* buffer = new byte[allocAmount])
				{

					// we're allocation on heap, not on stack cuz FileShare needs persistance so fuck it
					int bytesRead;
					long offset = 0;

					while ((bytesRead = stream.Read(new Span<byte>(buffer, allocAmount))) > 0)
					{

						Unsafe.CopyBlock(fileBuffer + offset, buffer, (uint)bytesRead);
						offset += bytesRead;

					}

				}

			}

			ParseBuffer(fileBuffer, fileSize);

		}

		public void ParseBuffer(byte* buffer, long length) => throw new NotImplementedException(); // todo: code function

	}

}
