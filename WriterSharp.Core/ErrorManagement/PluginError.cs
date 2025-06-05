using System;


namespace WriterSharp.Core.ErrorManagement
{

	/// <summary>
	/// Represents a cachable plugin error.
	/// </summary>
	/// <param name="PluginName">The name of the plugin that caused this error</param>
	/// <param name="ErrorCode">The error code</param>
	/// <param name="Message">The error message</param>
	/// <param name="Exception">The exception that caused this error</param>
	public record PluginError
	(

		string PluginName, // the name of the plugin that caused this error
		int ErrorCode,
		string Message,
		Exception? Exception
		
	) : ICachableError;

}
