using System;


namespace WriterSharp.Core.ErrorManagement
{

	public record PluginError
	(

		string PluginName, // the name of the plugin that caused this error
		int ErrorCode,
		string Message,
		Exception? Exception
		
	) : ICachableError;

}
