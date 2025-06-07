namespace WriterSharp.Plugins.PluginAPI
{

	/// <summary>
	/// Represe
	/// </summary>
	public interface IPlugin
	{

		/// <summary>
		/// The plugin's ID.
		/// </summary>
		string Id { get; set; }

		/// <summary>
		/// The plugin's name.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// The plugin's author.
		/// </summary>
		string Author { get; set; }

		/// <summary>
		/// The plugin's version.
		/// </summary>
		string Version { get; set; }

		/// <summary>
		/// The plugin's description.
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// The plugin context.
		/// </summary>
		IPluginContext PluginContext { get; set; }

		/// <summary>
		/// Method that's ran on start.
		/// </summary>
		/// <param name="context">The plugin context.</param>
		void Initialize(IPluginContext context);

		/// <summary>
		/// Method that's ran on shutdown.
		/// </summary>
		void Shutdown();

	}

}
