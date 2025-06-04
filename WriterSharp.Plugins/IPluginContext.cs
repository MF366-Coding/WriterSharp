using System;

using WriterSharp.Abstractions.Logger;


namespace WriterSharp.Plugins
{

	/// <summary>
	/// Abstraction of a plugin context.
	/// </summary>
	public interface IPluginContext
	{

		/// <summary>
		/// The logger.
		/// </summary>
		(BaseLogger MainLogger, BaseLogger AltLogger) LoggerGroup { get; set; }

	}

}
