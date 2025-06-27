namespace WriterSharp.PluginApi.V0.Utils
{

	/// <summary>
	/// Blueprint for loggers.
	/// </summary>
	public interface ILogger
	{

		/// <summary>
		/// Logs an info message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		void Info(string message);

		/// <summary>
		/// Logs a warning message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		void Warning(string message);

		/// <summary>
		/// Logs an error message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		void Error(string message);

		/// <summary>
		/// Logs a success message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		void Success(string message);

		/// <summary>
		/// Logs a neutral message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		void Message(string message);

	}

}
