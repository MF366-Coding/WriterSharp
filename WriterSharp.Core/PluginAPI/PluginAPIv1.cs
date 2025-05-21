using System;
using WriterSharp.PluginAPI;
using WriterSharp.PluginAPI.Keybindings;
using WriterSharp.PluginAPI.Tools;


namespace WriterSharp.Core.PluginAPI
{

	public class PluginAPIv1 : IPluginAPI
	{

		public uint APIVersion { get; init; }
		public ILogger Logger { get; init; }

		/// <summary>
		/// Create an instance of the the plugin API (version 1),
		/// with a custom logger.
		/// </summary>
		/// <param name="logger">The custom logger to use</param>
		public PluginAPIv1(ILogger logger)
		{

			APIVersion = 1;
			Logger = logger;

		}

		public void Subscribe<TEvent>(Action<TEvent> handler)
			where TEvent : IPluginEvent
		{

			// todo
			throw new NotImplementedException();

		}

		public void Unsubscribe<TEvent>(Action<TEvent> handler)
			where TEvent : IPluginEvent
		{

			// todo
			throw new NotImplementedException();

		}

		public void RegisterKeybinding(int key, byte keyModifiers, Action command)
		{

			// todo
			throw new NotImplementedException();

		}

		public void RegisterKeybinding(KeybindingKey key, KeybindingModifier keyModifiers, Action command)
		{

			// todo
			throw new NotImplementedException();

		}

		public void ReloadKeybindings()
		{

			// todo
			throw new NotImplementedException();

		}

	}

}
