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
		Task<string> ReadAllTextAsync(string filepath);

		/// <summary>
		/// Reads all text from a file, as a list of lines.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The contents of the file</returns>
		Task<string[]> ReadAllLinesAsync(string filepath);

		/// <summary>
		/// Reads the very first line of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>The first line of the file</returns>
		Task<string> ReadLineAsync(string filepath);

		/// <summary>
		/// Reads a specific amount of characters from a file buffer.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="amount">The amount of characters to read</param>
		/// <param name="offset">The index from which to start reading the characters</param>
		/// <returns>A span of characters</returns>
		Task<nint> ReadCharactersAsync(string filepath, ulong amount, long offset = 0);

		/// <summary>
		/// Writes text to a file, creating it if necessary. If the file exists,
		/// it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to write</param>
		Task WriteAllTextAsync(string filepath, string data);

		/// <summary>
		/// Writes lines of text to a file, creating it if necessary.
		/// If the file exists, it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines of text to write</param>
		Task WriteAllLinesAsync(string filepath, string[] data);

		/// <summary>
		/// Appends all the text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to append</param>
		Task AppendAllTextAsync(string filepath, string data);

		/// <summary>
		/// Appends all the specified lines of text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines to append</param>
		Task AppendAllLinesAsync(string filepath, string[] data);

		/// <summary>
		/// Checks if a file is in use by another plugin.
		/// A result of <c>false</c> does not mean the file is strictly
		/// not in use - it only means no other plugin is using it.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns><c>true</c> if in use by another plugin</returns>
		bool InUse(string filepath);

		/// <summary>
		/// Locks a file, to prevent it from being accessed by other plugins.
		/// </summary>
		/// <param name="filepath">The path to the file to lock</param>
		Task LockAsync(string filepath);

		/// <summary>
		/// Unlocks a previously locked file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		Task UnlockAsync(string filepath);

		/// <summary>
		/// Checks if a file is locked.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="lockOwnerIsCaller"><c>true</c> if the caller is the owner of the lock placed on this file</param>
		/// <returns><c>true</c> if the file is locked, no matter who owns the lock</returns>
		bool IsLocked(string filepath, out bool lockOwnerIsCaller);

		/// <summary>
		/// Checks if a file is locked by the caller.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns><c>true</c> if the file is locked and the lock owner is the caller</returns>
		bool IsLockedByMe(string filepath);

		/// <summary>
		/// Checks if a file is considered "lockable" (allows locking)
		/// by WriterSharp.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns><c>true</c> if it can be locked</returns>
		bool IsLockable(string filepath);

		/// <inheritdoc cref="System.IO.File.OpenRead(string)" />
		Task<FileStream> OpenReadAsync(string filepath);

		/// <inheritdoc cref="System.IO.File.OpenWrite(string)" />
		Task<FileStream> OpenWriteAsync(string filepath);

		/// <inheritdoc cref="System.IO.File.OpenText(string)" />
		Task<FileStream> OpenTextAsync(string filepath);

		/// <inheritdoc cref="System.IO.File.Open(string, FileMode, FileAccess, FileShare)" />
		Task<FileStream> OpenAsync(
			string filepath,
			FileMode mode,
			FileAccess access,
			FileShare share
		);

		/// <summary>
		/// Reads all text from a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		/// <returns>The contents of the file</returns>
		Task<string> ReadAllTextAsync(string filepath, CancellationToken cancellationToken);

		/// <summary>
		/// Reads all text from a file, as a list of lines.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		/// <returns>The contents of the file</returns>
		Task<string[]> ReadAllLinesAsync(string filepath, CancellationToken cancellationToken);

		/// <summary>
		/// Reads the very first line of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		/// <returns>The first line of the file</returns>
		Task<string> ReadLineAsync(string filepath, CancellationToken cancellationToken);

		/// <summary>
		/// Reads a specific amount of characters from a file buffer.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="amount">The amount of characters to read</param>
		/// <param name="offset">The index from which to start reading the characters</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		/// <returns>A span of characters</returns>
		Task<nint> ReadCharactersAsync(string filepath, ulong amount, long offset, CancellationToken cancellationToken);

		/// <summary>
		/// Writes text to a file, creating it if necessary. If the file exists,
		/// it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to write</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		Task WriteAllTextAsync(string filepath, string data, CancellationToken cancellationToken);

		/// <summary>
		/// Writes lines of text to a file, creating it if necessary.
		/// If the file exists, it will be overwritten.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines of text to write</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		Task WriteAllLinesAsync(string filepath, string[] data, CancellationToken cancellationToken);

		/// <summary>
		/// Appends all the text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The text to append</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		Task AppendAllTextAsync(string filepath, string data, CancellationToken cancellationToken);

		/// <summary>
		/// Appends all the specified lines of text to the end of a file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="data">The lines to append</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		Task AppendAllLinesAsync(string filepath, string[] data, CancellationToken cancellationToken);

		/// <summary>
		/// Locks a file, to prevent it from being accessed by other plugins.
		/// </summary>
		/// <param name="filepath">The path to the file to lock</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		Task LockAsync(string filepath, CancellationToken cancellationToken);

		/// <summary>
		/// Unlocks a previously locked file.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="cancellationToken">The cancellation token to trace</param>
		Task UnlockAsync(string filepath, CancellationToken cancellationToken);

		/// <inheritdoc cref="System.IO.File.OpenRead(string)" />
		Task<FileStream> OpenReadAsync(string filepath, CancellationToken cancellationToken);

		/// <inheritdoc cref="System.IO.File.OpenWrite(string)" />
		Task<FileStream> OpenWriteAsync(string filepath, CancellationToken cancellationToken);

		/// <inheritdoc cref="System.IO.File.OpenText(string)" />
		Task<FileStream> OpenTextAsync(string filepath, CancellationToken cancellationToken);

		/// <inheritdoc cref="System.IO.File.Open(string, FileMode, FileAccess, FileShare)" />
		Task<FileStream> OpenAsync(
			string filepath,
			FileMode mode,
			FileAccess access,
			FileShare share,
			CancellationToken cancellationToken
		);

	}

}
