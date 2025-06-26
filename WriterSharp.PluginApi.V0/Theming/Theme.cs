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
		/// The colors of the theme (UI).
		/// </summary>
		public Dictionary<string, string> Colors { get; } = [];

		/// <summary>
		/// The colors of the theme (syntax highlighting).
		/// </summary>
		public Dictionary<string, TextFormatting> TokenColors { get; } = [];

	}

}
