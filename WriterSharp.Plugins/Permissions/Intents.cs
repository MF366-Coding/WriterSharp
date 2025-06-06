namespace WriterSharp.Plugins.Permissions
{

	/// <summary>
	/// Intents for permission queries.
	/// </summary>
	public enum Intents
	{

		/// <summary>
		/// No intents.
		/// </summary>
		None = 1,

		/// <summary>
		/// Read and write access to the plugin manager.
		/// </summary>
		PluginManager = 2,

		/// <summary>
		/// Read and write access to the settings manager.
		/// </summary>
		SafeSettingsManager = 4

	}

}
