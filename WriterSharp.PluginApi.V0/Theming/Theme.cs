using System.Collections.Generic;


namespace WriterSharp.PluginApi.V0.Theming
{

	/// <summary>
	/// Represents a WriterSharp theme.
	/// </summary>
	public class Theme
	{

		/// <summary>
		/// The name of the theme.
		/// </summary>
		public required string Name { get; set; }
		
		/// <summary>
		/// The flavor (colors of the UI theme).
		/// </summary>
		public Dictionary<string, string> Flavor { get; } = [];

		/// <summary>
		/// The actual theme itself (colors of the editor).
		/// </summary>
		public Dictionary<string, TextFormatting> TokenColors { get; } = [];

	}

}
