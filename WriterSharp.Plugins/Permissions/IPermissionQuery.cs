using System.Collections.ObjectModel;

using WriterSharp.Plugins.PluginAPI;


namespace WriterSharp.Plugins.Permissions
{

	/// <summary>
	/// Blueprint for the Permission Query classes.
	/// </summary>
	public interface IPermissionQuery
	{

		/// <summary>
		/// Describes an intent.
		/// </summary>
		/// <param name="intent">You may pass multiple intents to describe, but remember they'll be combined.</param>
		/// <returns>A description of the intent in English</returns>
		string? DescribeIntent(Intents intent);

		/// <summary>
		/// Asks for permission from the user to enable intents.
		/// Do not authenticate multiple times: if you want all intents to be in use, separate them with the bytewise OR operator.
		/// </summary>
		/// <param name="intent">
		/// Intents to authorize.
		/// Including the <strong>None</strong> intent will cancel the operation.
		/// <code>
		/// Intents.SomeIntent | Intents.AnotherIntent | ...
		/// </code>
		/// </param>
		/// <returns>Information about the user's choice.</returns>
		ReturnData AskForPermission(Intents intent);

		/// <summary>
		/// Returns the intents used by a plugin.
		/// </summary>
		/// <param name="plugin">The plugin whose intents to view</param>
		/// <returns>A readonly list of intents</returns>
		ReadOnlyCollection<Intents> GetPluginIntents(IPlugin plugin);

		/// <summary>
		/// Removes intents from a specific plugin.
		/// </summary>
		/// <param name="plugin">The plugin whose intents to remove. Use | when choosing multiple.</param>
		/// <param name="intent">The intents to remove</param>
		/// <returns>Information about the operation.</returns>
		ReturnData WithdrawIntents(IPlugin plugin, Intents intent);

	}

}
