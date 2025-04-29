 /*
  *    _     _                   _       ___    _          _              
  *   /_\   | |__   ___   _  _  | |_    |   \  (_)  __ _  | |  ___   __ _ 
  *  / _ \  | '_ \ / _ \ | || | |  _|   | |) | | | / _` | | | / _ \ / _` |
  * /_/ \_\ |_.__/ \___/  \_,_|  \__|   |___/  |_| \__,_| |_| \___/ \__, |
  *                                                                 |___/ 
  *                                                                 
  * MIT License * MF366
  *                                                                 
  */


// System
using System;

// Avalonia
using Avalonia.Controls;
using Avalonia.Interactivity;

// Internal
using WriterSharp.Browser;


namespace WriterSharp
{

	public partial class AboutDialog : Window
	{

		/// <summary>
		/// Initializes the <strong>About</strong> window.
		/// </summary>
		public AboutDialog()
		{

			InitializeComponent();

		}

		/// <summary>
		/// Handle the "Learn More" button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OnClickLearnMore(object? sender, RoutedEventArgs e) => await BrowserService.OpenURLAsync(Constants.WriterSharpWebURL);

		/// <summary>
		/// Closes the window on the press of the matching button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickClose(object? sender, RoutedEventArgs e) => Close();
	
	}

}
