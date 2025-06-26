using System;


namespace WriterSharp.PluginApi.V0.Language
{

	/// <summary>
	/// Blueprint for language managers.
	/// </summary>
	public interface ILanguageManager
	{

		/// <summary>
		/// Registers a language into WriterSharp.
		/// </summary>
		/// <param name="language">The language</param>
		/// <returns>A GUID that can be used to unregister this language later on</returns>
		public Guid RegisterLanguage(
			LanguageDefinition language
		);

		/// <summary>
		/// Retrieves a registered language.
		/// </summary>
		/// <param name="id">The language ID</param>
		/// <returns>The language</returns>
		public LanguageDefinition GetLanguage(
			string id
		);

		/// <summary>
		/// Checks if a language is registered.
		/// </summary>
		/// <param name="id">The language ID</param>
		/// <returns>Is the language registered?</returns>
		public bool IsRegistered(
			string id
		);

		/// <summary>
		/// Checks if a language is registered.
		/// </summary>
		/// <param name="language">The language</param>
		/// <returns>Is the language registered?</returns>
		public bool IsRegistered(
			LanguageDefinition language
		);

		/// <summary>
		/// Retrieves a registered language by one of its extensions.
		/// </summary>
		/// <param name="fileExtension">One of the language's extensions</param>
		/// <returns>The language</returns>
		public LanguageDefinition GetLanguageByExtension(
			string fileExtension
		);

		/// <summary>
		/// Retrieves a registered language by its grammar.
		/// </summary>
		/// <param name="grammar">One of the language's grammars</param>
		/// <returns>The language</returns>
		public LanguageDefinition GetLanguageByGrammar(
			string grammar
		);

		/// <summary>
		/// Unregisters the language associated with the specified GUID.
		/// </summary>
		/// <param name="associatedGuid">The GUID that was given at creation</param>
		/// <returns><c>true</c> if successful</returns>
		public bool UnregisterLanguage(
			Guid associatedGuid
		);

	}

}
