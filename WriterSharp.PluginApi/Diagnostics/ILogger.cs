using System;
using System.Threading.Tasks;


namespace WriterSharp.PluginApi.Diagnostics
{

	/// <summary>
	/// A logger.
	/// </summary>
	public interface ILogger
	{

		/// <summary>
		/// Creates a new rotation (session) in the logger.
		/// </summary>
		void CreateSession();

		/// <summary>
		/// Logs a message with default severity at current time.
		/// </summary>
		/// <param name="message">The message</param>
		Task Log(object? message);

		/// <summary>
		/// Logs a message with default severity at current time.
		/// </summary>
		/// <param name="message">The message</param>
		Task Log(string message);

		/// <summary>
		/// Logs a message with a given format, default severity at current time.
		/// </summary>
		/// <param name="format">The format</param>
		/// <param name="items">The items to fill in</param>
		Task Log(string format, params object?[] items);

		/// <summary>
		/// Logs a message at current time.
		/// </summary>
		/// <param name="message">The message</param>
		/// <param name="severityLevel">The severity level</param>
		Task Log(object? message, SeverityLevel severityLevel);

		/// <summary>
		/// Logs a message at current time.
		/// </summary>
		/// <param name="message">The message</param>
		/// <param name="severityLevel">The severity level</param>
		Task Log(string message, SeverityLevel severityLevel);

		/// <summary>
		/// Logs a message.
		/// </summary>
		/// <param name="message">The message</param>
		/// <param name="severityLevel">The severity level</param>
		/// <param name="dateTime">The timestamp</param>
		Task Log(object? message, SeverityLevel severityLevel, DateTime dateTime);

		/// <summary>
		/// Logs a message.
		/// </summary>
		/// <param name="message">The message</param>
		/// <param name="severityLevel">The severity level</param>
		/// <param name="dateTime">The timestamp</param>
		Task Log(string message, SeverityLevel severityLevel, DateTime dateTime);

	}

}
