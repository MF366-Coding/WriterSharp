using System;


namespace WriterSharp.PluginApi.FileSystem
{

	/// <summary>
	/// A type-safe, flexible, sharded file-system for WriterSharp plugins to use for
	/// maximum safety, instead of the defaults.
	/// </summary>
	public interface IFileSystem
	{

		#region Reading

		/// <summary>
		/// Reads all text from a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The contents of the file</returns>
		public string ReadAllText(string filepath);

		/// <summary>
		/// Reads all text from a file.
		/// </summary>
		/// <param name="file">The file</param>
		/// <returns>The contents of the file</returns>
		public string ReadAllText(IFile file);

		/// <summary>
		/// Reads all text from a file, as a list of lines.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The contents of the file</returns>
		public string[] ReadAllLines(string filepath);

		/// <summary>
		/// Reads all text from a file, as a list of lines.
		/// </summary>
		/// <param name="file">The file</param>
		/// <returns>The contents of the file</returns>
		public string[] ReadAllLines(IFile file);

		/// <summary>
		/// Reads the very first line of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The first line of the file</returns>
		public string ReadLine(string filepath);

		/// <summary>
		/// Reads the very first line of a file.
		/// </summary>
		/// <param name="file">The file</param>
		/// <returns>The first line of the file</returns>
		public string ReadLine(IFile file);

		/// <summary>
		/// Reads a specific amount of characters from a file buffer.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="amount">The amount of characters to read</param>
		/// <param name="offset">The index from which to start reading the characters</param>
		/// <returns>A span of characters</returns>
		public Span<char> ReadCharacters(string filepath, ulong amount, long offset = 0);

		/// <summary>
		/// Reads a specific amount of characters from a file buffer.
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="amount">The amount of characters to read</param>
		/// <param name="offset">The index from which to start reading the characters</param>
		/// <returns>A span of characters</returns>
		public Span<char> ReadCharacters(IFile file, ulong amount, long offset = 0);

		#endregion

		#region Writing

		/// <summary>
		/// Writes text to a file, creating it if necessary. If the file exists,
		/// it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to write</param>
		public void WriteAllText(string filepath, string data);

		/// <summary>
		/// Writes text to a file, creating it if necessary. If the file exists,
		/// it will be overwritten.
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="data">The text to write</param>
		public void WriteAllText(IFile file, string data);

		/// <summary>
		/// Writes lines of text to a file, creating it if necessary.
		/// If the file exists, it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines of text to write</param>
		public void WriteAllLines(string filepath, string[] data);

		/// <summary>
		/// Writes lines of text to a file, creating it if necessary.
		/// If the file exists, it will be overwritten.
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="data">The lines of text to write</param>
		public void WriteAllLines(IFile file, string[] data);

		#endregion

		#region Appending

		/// <summary>
		/// Appends all the text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to append</param>
		public void AppendAllText(string filepath, string data);

		/// <summary>
		/// Appends all the text to the end of a file.
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="data">The text to append</param>
		public void AppendAllText(IFile file, string data);

		/// <summary>
		/// Appends all the specified lines of text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines to append</param>
		public void AppendAllLines(string filepath, string[] data);

		/// <summary>
		/// Appends all the specified lines of text to the end of a file.
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="data">The lines to append</param>
		public void AppendAllLines(IFile file, string[] data);

		#endregion

		#region Sharding Toolkit

		/// <summary>
		/// Checks if a file is in use by another plugin.
		/// A result of <c>false</c> does not mean the file is strictly
		/// not in use - it only means no other plugin is using it.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns><c>true</c> if in use by another plugin</returns>
		public bool InUse(string filepath);

		/// <summary>
		/// Checks if a file is in use by another plugin.
		/// A result of <c>false</c> does not mean the file is strictly
		/// not in use - it only means no other plugin is using it.
		/// </summary>
		/// <param name="filepath">The file</param>
		/// <returns><c>true</c> if in use by another plugin</returns>
		public bool InUse(IFile filepath);

		#endregion

		#region Locking

		// todo: this shit

		#endregion

	}

}
