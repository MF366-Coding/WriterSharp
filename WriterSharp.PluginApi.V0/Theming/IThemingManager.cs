using System.IO;
using System.Text.Json.Nodes;


namespace WriterSharp.PluginApi.V0.Theming
{

	/// <summary>
	/// Blueprint for theme managers.
	/// </summary>
	public interface IThemingManager
	{

		/// <summary>
		/// Registers a theme.
		/// </summary>
		/// <param name="theme">The theme to register.</param>
		void Register(Theme theme);

		/// <summary>
		/// Sets a flavor from a theme.
		/// </summary>
		/// <param name="theme">The theme whose flavor to set.</param>
		void SetFlavor(Theme theme);

		/// <summary>
		/// Sets a flavor from a theme file.
		/// </summary>
		/// <param name="themeFile">The file of the theme.</param>
		void SetFlavor(FileInfo themeFile);

		/// <summary>
		/// Sets an editor theme from a theme.
		/// </summary>
		/// <param name="theme">The theme whose editor theme to set.</param>
		void SetTheme(Theme theme);

		/// <summary>
		/// Sets an editor theme from a theme file.
		/// </summary>
		/// <param name="themeFile">The file of the theme.</param>
		void SetTheme(FileInfo themeFile);

		/// <summary>
		/// Converts a theme to JSON format.
		/// </summary>
		/// <param name="theme">The theme to convert.</param>
		/// <returns>The root JSON node</returns>
		JsonObject ToJson(Theme theme);

	}

}
