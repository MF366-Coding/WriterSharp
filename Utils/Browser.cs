/*
 *  ___                                       
 * | _ )  _ _   ___  __ __ __  ___  ___   _ _ 
 * | _ \ | '_| / _ \ \ V  V / (_-< / -_) | '_|
 * |___/ |_|   \___/  \_/\_/  /__/ \___| |_|  
 *                 
 * MIT License * MF366
 *                 
 */


// System
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;


namespace WriterSharp.Browser
{

	/// <summary>
	/// Browser-related operations.
	/// </summary>
	public static class BrowserService
	{

		/// <summary>
		/// Open a URL with the default webbrowser.
		/// </summary>
		/// <param name="url">The URL to open</param>
		/// <returns>0 if successful or -1 if an error was caught</returns>
		public static int OpenURL(string url)
		{

			try
			{

				ProcessStartInfo psi = new()
				{

					FileName = url,
					UseShellExecute = true

				};
				Process.Start(psi);
				return 0;

			}

			catch (Exception)
			{

				return -1;

			}

		}

		/// <summary>
		/// Opens a URL with the default webbrowser, but asyncronously.
		/// </summary>
		/// <param name="url">The URL to open.</param>
		/// <returns>Null if an error was caught</returns>
		public static async Task<Process?> OpenURLAsync(string url)
		{

			try
			{

				ProcessStartInfo psi = new()
				{

					FileName = url,
					UseShellExecute = true

				};

				return await Task.Run(() => Process.Start(psi));

			}
			catch (Exception)
			{

				return null;

			}

		}

	}

}
