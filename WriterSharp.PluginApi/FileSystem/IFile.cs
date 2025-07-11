namespace WriterSharp.PluginApi.FileSystem
{

	/// <summary>
	/// Represents a file on disk.
	/// Data-only structure.
	/// </summary>
	public interface IFile
	{

		/// <summary>
		/// An absolute path to the file.
		/// </summary>
		public string AbsoluteFilepath { get; }

		/// <summary>
		/// The name of the file.
		/// </summary>
		public string Name { get; }

	}

}
