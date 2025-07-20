using System;
using System.IO;


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
		/// Reads all text from a file, as a list of lines.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The contents of the file</returns>
		public string[] ReadAllLines(string filepath);

		/// <summary>
		/// Reads the very first line of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The first line of the file</returns>
		public string ReadLine(string filepath);

		/// <summary>
		/// Reads a specific amount of characters from a file buffer.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="amount">The amount of characters to read</param>
		/// <param name="offset">The index from which to start reading the characters</param>
		/// <returns>A span of characters</returns>
		public Span<char> ReadCharacters(string filepath, ulong amount, long offset = 0);

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
		/// Writes lines of text to a file, creating it if necessary.
		/// If the file exists, it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines of text to write</param>
		public void WriteAllLines(string filepath, string[] data);

		#endregion

		#region Appending

		/// <summary>
		/// Appends all the text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to append</param>
		public void AppendAllText(string filepath, string data);

		/// <summary>
		/// Appends all the specified lines of text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines to append</param>
		public void AppendAllLines(string filepath, string[] data);

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

		#endregion

		#region Locking

		/// <summary>
		/// Locks a file, to prevent it from being accessed by other plugins.
		/// </summary>
		/// <param name="filepath">The path to the file to lock</param>
		public void Lock(string filepath);

		/// <summary>
		/// Unlocks a previously locked file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		public void Unlock(string filepath);

		/// <summary>
		/// Checks if a file is locked.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="lockOwnerIsCaller"><c>true</c> if the caller is the owner of the lock placed on this file</param>
		/// <returns><c>true</c> if the file is locked, no matter who owns the lock</returns>
		public bool IsLocked(string filepath, out bool lockOwnerIsCaller);

		/// <summary>
		/// Checks if a file is locked by the caller.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns><c>true</c> if the file is locked and the lock owner is the caller</returns>
		public bool IsLockedByMe(string filepath) => IsLocked(filepath, out var byMe) && byMe;

		/// <summary>
		/// Checks if a file is considered "lockable" (allows locking)
		/// by WriterSharp.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns><c>true</c> if it can be locked</returns>
		public bool IsLockable(string filepath);

		#endregion

		#region Stream

		/// <inheritdoc cref="File.OpenRead(String)" />
		public FileStream OpenRead(string filepath);

		/// <inheritdoc cref="File.OpenWrite(String)" />
		public FileStream OpenWrite(string filepath);

		/// <inheritdoc cref="File.OpenText(String)" />
		public FileStream OpenText(string filepath);

		/// <inheritdoc cref="File.Open(String, FileMode, FileAccess, FileShare)" />
		public FileStream Open(string filepath, FileMode mode, FileAccess access, FileShare share);

		#endregion

	}

}
