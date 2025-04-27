 /*
  *  ___          _                    ___         _          _   
  * | __|  _ _   | |_   _ _   _  _    | _ \  ___  (_)  _ _   | |_ 
  * | _|  | ' \  |  _| | '_| | || |   |  _/ / _ \ | | | ' \  |  _|
  * |___| |_||_|  \__| |_|    \_, |   |_|   \___/ |_| |_||_|  \__|
  *                           |__/       
  *                           
  * MIT License * MF366
  *                           
  */


// System
using System;

// Avalonia
using Avalonia;


namespace WriterSharp
{

    /// <summary>
    /// Entry point class for WriterSharp.
    /// </summary>
    internal class Program
    {

		/// <summary>
		/// WriterSharp's method entry point.
		/// <br/><br/>
		/// <strong>Message from Avalona:</strong>
		/// <br/>
		/// Initialization code. Don't use any Avalonia, third-party APIs or any
		/// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
		/// yet and stuff might break.
		/// </summary>
		/// <param name="args">Commandline arguments</param>

		[STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        /// <summary>
        /// Avalonia configuration. Not to be removed. Used by the visual designer too.
        /// </summary>
        /// <returns>AppBuilder</returns>
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();

    }

}
