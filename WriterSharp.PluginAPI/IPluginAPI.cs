using System;

using WriterSharp.PluginAPI.Keybindings;
using WriterSharp.PluginAPI.Tools;


namespace WriterSharp.PluginAPI
{

	public interface IPluginAPI
	{

		/// <summary>
		/// The version of the API your plugin is using.
		/// </summary>
		uint APIVersion { get; }

		/// <summary>
		/// WriterSharp Logger available for debugging.
		/// </summary>
		ILogger Logger { get; }

		void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : IPluginEvent;

		void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : IPluginEvent;

		void RegisterKeybinding(int key, byte keyModifiers, Action command);
		
		void RegisterKeybinding(KeybindingKey key, KeybindingModifier keyModifiers, Action command);

		[Obsolete("Please use RegisterKeybinding((int)<your-osx-only-key>, <modifiers>, <command>) instead")]
		void RegisterKeybinding(KeybindingOSXOnly osxOnlyKey, KeybindingModifier keyModifiers, Action command);

		/// <summary>
		/// Reloads all of WriterSharp's keybindings. Use this only if you wish to remove a keybinding you binded.
		/// This might be an expensive computation depending on user setup, so please use it carefully.
		/// </summary>
		void ReloadKeybindings();

	}

}
