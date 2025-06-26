using WriterSharp.PluginApi.V0.Language;


namespace WriterSharp.PluginApi.V0
{

	/// <summary>
	/// Blueprint for plugin contexts.
	/// </summary>
	public interface IPluginContext
	{

		// todo: code logger and file service interfaces
		ILogger Logger { get; set; }

		IFileService FileService { get; set; }

		/// <summary>
		/// The global WriterSharp language manager.
		/// </summary>
		ILanguageManager LanguageManager { get; set; }

	}

}
