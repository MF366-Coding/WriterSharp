using System.IO;


namespace WriterSharp.PluginApi.V0.Utils
{

	/// <summary>
	/// Blueprint for file services.
	/// </summary>
	public interface IFileService
	{

		/// <summary>
		/// <c>true</c> if the current file is saved.
		/// </summary>
		bool IsCurrentOpenSaved { get; }

		/// <summary>
		/// Gets the current open file.
		/// Might fail if the current open file doesn't exist on disk
		/// yet.
		/// </summary>
		/// <exception cref="FileNotFoundException" />
		/// <returns>The file if one exists</returns>
		FileInfo GetCurrentOpen();

		/// <summary>
		/// Tries to get the current open file.
		/// </summary>
		/// <param name="file">The file that's currently open or null if it doesn't exist on disk yet</param>
		/// <returns><c>true</c> if the current file exists on disk</returns>
		bool TryGetCurrentOpen(out FileInfo? file);

		/// <summary>
		/// Opens a file.
		/// </summary>
		/// <param name="file">The file to open.</param>
		void Open(FileInfo file);

		/// <summary>
		/// Saves the current file as another.
		/// </summary>
		/// <param name="newFile">The output file</param>
		void SaveAs(FileInfo newFile);

		/// <summary>
		/// Saves and closes the current file.
		/// </summary>
		void Close();

		/// <summary>
		/// Closes the current file.
		/// </summary>
		/// <param name="force">If <c>true</c>, will <strong>NOT</strong> save before closing.</param>
		void Close(bool force);

	}

}
