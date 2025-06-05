namespace WriterSharp.Plugins.Logger
{

	/// <summary>
	/// Abstraction of a logger.
	/// </summary>
	public abstract class BaseLogger
	{

		/// <summary>
		/// The output path to the logger.
		/// If null, uses <see cref="System.Console" />.
		/// </summary>
		string? OutputPath { get; init; }

		/// <summary>
		/// Logs a timestamp to the logger.
		/// </summary>
		public abstract void Log();

		/// <summary>
		/// Logs a timestamped message.
		/// </summary>
		/// <param name="message">The message to log</param>
		public abstract void Log(string message);

		/// <summary>
		/// Logs a timestamped message with a specific
		/// severity level.
		/// </summary>
		/// <param name="message">The message to log</param>
		/// <param name="logSeverity">The severity level to apply</param>
		public abstract void Log(string message, LogSeverity logSeverity);

		/// <summary>
		/// Logs a timestamped message with a specific
		/// severity level and pretty-printing (if applicable
		/// - <i>only if logging to the <see cref="System.Console" /></i> -
		/// and specified).
		/// </summary>
		/// <param name="message"></param>
		/// <param name="logSeverity"></param>
		/// <param name="prettyPrint"></param>
		public abstract void Log(string message, LogSeverity logSeverity, bool prettyPrint);

	}

}
