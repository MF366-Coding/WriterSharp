using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace WriterSharp.PluginApi.Settings
{

	/// <summary>
	/// Manages WriterSharp's plugin's settings globally.
	/// This does not mean plugins can't have their own individual
	/// settings files, but it's recommended to use this structure of plugin design.
	/// </summary>
	public interface ISettingsManager
	{

		/// <summary>
		/// Checks if the settings file is in use by another plugin.
		/// </summary>
		/// <returns><c>true</c> if in use</returns>
		bool InUse();

		/// <summary>
		/// Gets the plugin's section.
		/// </summary>
		/// <returns>The section, as a dictionary</returns>
		/// <remarks>Useful if you're going to be editing the settings a lot.</remarks>
		Task<Dictionary<string, string>> GetSectionAsync();

		/// <summary>
		/// Update's the plugin's section.
		/// </summary>
		/// <param name="section">The new version of the section</param>
		void UpdateSectionAsync(Dictionary<string, string> section);

		// ReSharper disable once GrammarMistakeInComment
		/// <summary>
		/// Retrieves a value from the plugin's section given a key. If the key is missing, an exception is thrown.
		/// </summary>
		/// <param name="key">The key that matches the value</param>
		/// <returns>A string or <c>null</c> if the value was <c>nil</c>.</returns>
		Task<string?> GetValueAsync(string key);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="value">The value</param>
		Task SetValueAsync(string key, string value);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="value">The value. It is converted to string</param>
		Task SetValueAsync(string key, int value);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="value">The value. It is converted to string</param>
		Task SetValueAsync(string key, bool value);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="value">The value</param>
		Task SetValueAsync(string key, object? value);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="pair">A key-value pair containing a key string and a value string</param>
		Task SetValueAsync(KeyValuePair<string, string?> pair);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="pair">A key-value pair containing a key string and a value integer</param>
		Task SetValueAsync(KeyValuePair<string, int> pair);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="pair">A key-value pair containing a key string and a value boolean</param>
		Task SetValueAsync(KeyValuePair<string, bool> pair);

		/// <summary>
		/// Gets the plugin's section.
		/// </summary>
		/// <param name="cancellationToken">A cancellation token to stop WriterSharp from getting the section</param>
		/// <returns>The section, as a dictionary</returns>
		/// <remarks>Useful if you're going to be editing the settings a lot.</remarks>
		Task<Dictionary<string, string>> GetSectionAsync(CancellationToken cancellationToken);

		/// <summary>
		/// Update's the plugin's section.
		/// </summary>
		/// <param name="section">The new version of the section</param>
		/// <param name="cancellationToken">A cancellation token</param>
		void UpdateSectionAsync(Dictionary<string, string> section, CancellationToken cancellationToken);

		/// <summary>
		/// Retrieves a value from the plugin's section given a key. If the key is missing, an exception is thrown.
		/// </summary>
		/// <param name="key">The key that matches the value</param>
		/// <param name="cancellationToken">A cancellation token</param>
		/// <returns>A string or <c>null</c> if the value was <c>nil</c>.</returns>
		Task<string?> GetValueAsync(string key, CancellationToken cancellationToken);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="value">The value</param>
		/// <param name="cancellationToken">A cancellation token</param>
		Task SetValueAsync(string key, string value, CancellationToken cancellationToken);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="value">The value. It is converted to string</param>
		/// <param name="cancellationToken">A cancellation token</param>
		Task SetValueAsync(string key, int value, CancellationToken cancellationToken);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="value">The value. It is converted to string</param>
		/// <param name="cancellationToken">A cancellation token</param>
		Task SetValueAsync(string key, bool value, CancellationToken cancellationToken);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="key">The key's name</param>
		/// <param name="value">The value</param>
		/// <param name="cancellationToken">A cancellation token</param>
		Task SetValueAsync(string key, object? value, CancellationToken cancellationToken);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="pair">A key-value pair containing a key string and a value string</param>
		/// <param name="cancellationToken">A cancellation token</param>
		Task SetValueAsync(KeyValuePair<string, string?> pair, CancellationToken cancellationToken);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="pair">A key-value pair containing a key string and a value integer</param>
		/// <param name="cancellationToken">A cancellation token</param>
		Task SetValueAsync(KeyValuePair<string, int> pair, CancellationToken cancellationToken);

		/// <summary>
		/// Sets an existing key to match a value or adds a new one if necessary.
		/// </summary>
		/// <param name="pair">A key-value pair containing a key string and a value boolean</param>
		/// <param name="cancellationToken">A cancellation token</param>
		Task SetValueAsync(KeyValuePair<string, bool> pair, CancellationToken cancellationToken);

	}

}
