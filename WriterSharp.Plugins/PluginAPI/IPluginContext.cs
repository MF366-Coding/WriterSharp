using System;

using WriterSharp.Plugins.Documents;
using WriterSharp.Plugins.Logger;


namespace WriterSharp.Plugins.PluginAPI
{

	/// <summary>
	/// Abstraction of a plugin context.
	/// </summary>
	public interface IPluginContext
	{

		/// <summary>
		/// The logger.
		/// </summary>
		(BaseLogger MainLogger, BaseLogger AltLogger) LoggerGroup { get; }

		/// <summary>
		/// The document manager.
		/// </summary>
		IDocumentManager DocumentManager { get; }

	}

}
