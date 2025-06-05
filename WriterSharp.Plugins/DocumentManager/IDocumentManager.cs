using System.Text;
using System.Threading.Tasks;


namespace WriterSharp.Plugins.DocumentManager
{

	/// <summary>
	/// Blueprint for the document manager.
	/// </summary>
	public interface IDocumentManager
	{

		/// <summary>
		/// The path to the current file or null if the file
		/// doesn't exist in the system yet.
		/// </summary>
		string? CurrentFile { get; }

		/// <summary>
		/// Whether the current file is saved or not.
		/// </summary>
		bool? CurrentFileIsSaved { get; }

		/// <summary>
		/// Opens a file at a specific filepath.
		/// </summary>
		/// <param name="filepath">The filepath</param>
		/// <returns>A record containing action return data.</returns>
		ReturnData OpenFile(string filepath);

		/// <summary>
		/// Opens a file at a specific filepath with
		/// the specified encoding.
		/// </summary>
		/// <param name="filepath">The filepath</param>
		/// <param name="encoding">The encoding</param>
		/// <returns>A record containing action return data.</returns>
		ReturnData OpenFile(string filepath, Encoding encoding);

		/// <summary>
		/// Opens a file at a given filepath with a specific encoding.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="encoding">The encoding</param>
		/// <param name="lineSeparationChar">
		/// The character(s) to consider as line separation characters.
		/// </param>
		/// <returns>A record containing action return data.</returns>
		ReturnData OpenFile(string filepath, Encoding encoding, string lineSeparationChar);

		/// <summary>
		/// Opens a file at a given filepath, asynchronously.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <returns>A record containing action return data.</returns>
		Task<ReturnData> OpenFileAsync(string filepath);

		/// <summary>
		/// Opens a file at a given filepath with
		/// a specified encoding, asynchronously.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="encoding">The encoding to open the file with</param>
		/// <returns>A record containing action return data.</returns>
		Task<ReturnData> OpenFileAsync(string filepath, Encoding encoding);

		/// <summary>
		/// Opens a file at a given filepath with
		/// a specified encoding, asynchronously.
		/// </summary>
		/// <param name="filepath">The path to the file</param>
		/// <param name="encoding">The encoding to open the file with</param>
		/// <param name="lineSeparationChar">The line separation character(s) to consider</param>
		/// <returns>A record containing action return data.</returns>
		Task<ReturnData> OpenFileAsync(string filepath, Encoding encoding, string lineSeparationChar);

		/// <summary>
		/// Saves the current file with the default properties.<br />
		/// If the current file is not in the system yet, this method will
		/// return a faulty <see cref="ReturnData" /> record.
		/// </summary>
		/// <returns>A record containing action return data.</returns>
		ReturnData SaveCurrentFile();

		/// <summary>
		/// Saves the current file with the default properties but to a different path.<br />
		/// Unlike when using Save As, this does NOT open the new path,
		/// still using the old one.
		/// </summary>
		/// <param name="newFilepath">The filepath to save the file to</param>
		/// <returns>A record containing action return data.</returns>
		ReturnData SaveCurrentFile(string newFilepath);

		/// <summary>
		/// Saves the current file with a given encoding but to a different path.<br />
		/// Unlike when using Save As, this does NOT open the new path,
		/// still using the old one.
		/// </summary>
		/// <param name="newFilepath">The filepath to save the file to</param>
		/// <param name="encoding">The encoding to save the file with</param>
		/// <returns>A record containing action return data.</returns>
		ReturnData SaveCurrentFile(string newFilepath, Encoding encoding);

		/// <summary>
		/// Saves the current file, asynchronously, with the default properties.<br />
		/// If the current file is not in the system yet, this method will
		/// call the Save As dialog.
		/// </summary>
		/// <returns>A record containing action return data.</returns>
		ReturnData SaveCurrentFileAsync();

		/// <summary>
		/// Saves the current file, asynchronously, with the default properties but to a different path.<br />
		/// Unlike when using Save As, this does NOT open the new path,
		/// still using the old one.
		/// </summary>
		/// <param name="newFilepath">The filepath to save the file to</param>
		/// <returns>A record containing action return data.</returns>
		ReturnData SaveCurrentFileAsync(string newFilepath);

		/// <summary>
		/// Saves the current file, asynchronously, with a given encoding but to a different path.<br />
		/// Unlike when using Save As, this does NOT open the new path,
		/// still using the old one.
		/// </summary>
		/// <param name="newFilepath">The filepath to save the file to</param>
		/// <param name="encoding">The encoding to save the file with</param>
		/// <returns>A record containing action return data.</returns>
		ReturnData SaveCurrentFileAsync(string newFilepath, Encoding encoding);

		/// <summary>
		/// Closes the current file (creates a new one).
		/// </summary>
		/// <returns>A record containing action return data.</returns>
		ReturnData CloseCurrentFile();

		/// <summary>
		/// Closes the current file asynchronously (creates a new one).
		/// </summary>
		/// <returns>A record containing action return data.</returns>
		ReturnData CloseCurrentFileAsync();

	}

}
