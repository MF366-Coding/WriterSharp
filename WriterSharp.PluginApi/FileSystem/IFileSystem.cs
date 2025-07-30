using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace WriterSharp.PluginApi.FileSystem
{

	/// <summary>
	/// A type-safe, flexible, sharded file-system for WriterSharp plugins to use for
	/// maximum safety, instead of the defaults.
	/// </summary>
	public interface IFileSystem
	{

		/// <summary>
		/// Reads all text from a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The contents of the file</returns>
		public Task<string> ReadAllTextAsync(string filepath, CancellationToken cancellationToken = default);

		/// <summary>
		/// Reads all text from a file, as a list of lines.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The contents of the file</returns>
		public Task<string[]> ReadAllLinesAsync(string filepath, CancellationToken cancellationToken = default);

		/// <summary>
		/// Reads the very first line of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The first line of the file</returns>
		public Task<string> ReadLineAsync(string filepath, CancellationToken cancellationToken = default);

		/// <summary>
		/// Reads a specific amount of characters from a file buffer.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="amount">The amount of characters to read</param>
		/// <param name="offset">The index from which to start reading the characters</param>
		/// <returns>A span of characters</returns>
		public Task<nint> ReadCharactersAsync(string filepath, ulong amount, long offset = 0, CancellationToken cancellationToken = default);

		/// <summary>
		/// Writes text to a file, creating it if necessary. If the file exists,
		/// it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to write</param>
		public Task WriteAllTextAsync(string filepath, string data, CancellationToken cancellationToken = default);

		/// <summary>
		/// Writes lines of text to a file, creating it if necessary.
		/// If the file exists, it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines of text to write</param>
		public Task WriteAllLinesAsync(string filepath, string[] data, CancellationToken cancellationToken = default);

		/// <summary>
		/// Appends all the text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to append</param>
		public Task AppendAllTextAsync(string filepath, string data, CancellationToken cancellationToken = default);

		/// <summary>
		/// Appends all the specified lines of text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines to append</param>
		public Task AppendAllLinesAsync(string filepath, string[] data, CancellationToken cancellationToken = default);

		/// <summary>
		/// Checks if a file is in use by another plugin.
		/// A result of <c>false</c> does not mean the file is strictly
		/// not in use - it only means no other plugin is using it.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns><c>true</c> if in use by another plugin</returns>
		public bool InUse(string filepath);

		/// <summary>
		/// Locks a file, to prevent it from being accessed by other plugins.
		/// </summary>
		/// <param name="filepath">The path to the file to lock</param>
		public Task LockAsync(string filepath, CancellationToken cancellationToken = default);

		/// <summary>
		/// Unlocks a previously locked file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		public Task UnlockAsync(string filepath, CancellationToken cancellationToken = default);

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

		/// <inheritdoc cref="System.IO.File.OpenRead(String)" />
		public Task<FileStream> OpenReadAsync(string filepath, CancellationToken cancellationToken = default);

		/// <inheritdoc cref="System.IO.File.OpenWrite(String)" />
		public Task<FileStream> OpenWriteAsync(string filepath, CancellationToken cancellationToken = default);

		/// <inheritdoc cref="System.IO.File.OpenText(String)" />
		public Task<FileStream> OpenTextAsync(string filepath, CancellationToken cancellationToken = default);

		/// <inheritdoc cref="System.IO.File.Open(String, FileMode, FileAccess, FileShare)" />
		public Task<FileStream> OpenAsync(
			string filepath,
			FileMode mode,
			FileAccess access,
			FileShare share,
			CancellationToken cancellationToken = default
		);

	}

}
