namespace WriterSharp.PluginApi.V0.Language
{

	/// <summary>
	/// Represents a language supported by WriterSharp (via the plugin).
	/// </summary>
	public class LanguageDefinition
	{

		/// <summary>
		/// A unique ID to give this language.
		/// </summary>
		public required string Id { get; set; }

		/// <summary>
		/// The file extensions that trigger this language.
		/// </summary>
		public string[] Extensions { get; set; } = [];

		/// <summary>
		/// The path to a TextMate grammar.
		/// You may also pass an identifier for a default grammar if,
		/// instead of a path, you pass a string in the following format:
		/// <code>&lt;grammar-name&gt;</code>
		/// Examples:
		/// <list type="bullet"><c>path/to/grammar</c> (path)</list>
		/// <list type="bullet"><c>grammar</c> (path)</list>
		/// <list type="bullet"><c>&lt;grammar&gt;</c> (default grammar of name "grammar")</list>
		/// </summary>
		public string? TextMateGrammarPath { get; set; }

	}

}
