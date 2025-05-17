namespace WriterSharp.PluginAPI.Tools
{

	public interface ILogger
	{

		/// <summary>
		/// Logs a message with an informational tone.
		/// </summary>
		void Info(string message);

		/// <summary>
		/// Logs a message with a warning tone.
		/// </summary>
		void Warning(string message);

		/// <summary>
		/// Logs a message with an error tone. Use this for critical errors only.
		/// </summary>
		void Error(string message);

		/// <summary>
		/// Logs a message with a success tone.
		/// </summary>
		/// <param name="message"></param>
		void Success(string message);

		/// <summary>
		/// Logs a message with no tone.
		/// </summary>
		/// <param name="message"></param>
		void Neutral(string message);

	}

	public class ConsoleLogger : ILogger
	{

		public void Info(string message) => Console.WriteLine($"[INFO] {message}");

		public void Warning(string message) => Console.WriteLine($"[WARNING] {message}");

		public void Error(string message) => Console.WriteLine($"[ERROR] {message}");

		public void Success(string message) => Console.WriteLine($"[SUCCESS] {message}");

		public void Neutral(string message) => Console.WriteLine(message);

		#region Pretty Printing

		public static void PrettyInfo(string message) => Console.WriteLine($"\033[96m[INFO] {message}");

		public static void PrettyWarning(string message) => Console.WriteLine($"\033[93m[WARNING] {message}");

		public static void PrettyError(string message) => Console.WriteLine($"\033[91m[ERROR] {message}");

		public static void PrettySuccess(string message) => Console.WriteLine($"\033[92m[SUCCESS] {message}");

		#endregion

	}

}
