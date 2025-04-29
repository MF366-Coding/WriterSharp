/*
 *  _      ___    ___   ___   _  _   ___   ___ 
 * | |    |_ _|  / __| | __| | \| | / __| | __|
 * | |__   | |  | (__  | _|  | .` | \__ \ | _| 
 * |____| |___|  \___| |___| |_|\_| |___/ |___|
 *                                                                                                     
 * MIT License * MF366
 *                                                                 
 */


// System
using System;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Security;


// Avalonia
using Avalonia.Controls;
using Avalonia.Interactivity;
using Tmds.DBus.Protocol;


// Internal
using WriterSharp.Browser;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WriterSharp
{

	public partial class LicenseDialog : Window
	{

		/// <summary>
		/// The LICENSE widget.
		/// </summary>
		readonly TextBox licenseText;

		/// <summary>
		/// WriterSharp's LICENSE.
		/// </summary>
		const string LICENSE = @"MIT License

Copyright(c) 2025 MF366

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files(the ""Software""), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
		AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
";

		/// <summary>
		/// Initializes the <strong>LICENSE</strong> window.
		/// </summary>
		public LicenseDialog()
		{

			InitializeComponent();
			licenseText = this.FindControl<TextBox>("LicenseTextBox")!;

			licenseText.Text = LICENSE;

		}

		/// <summary>
		/// Handle the "More about MIT License" button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OnClickLearnMore(object? sender, RoutedEventArgs e) => await BrowserService.OpenURLAsync("https://mit-license.org/");

		/// <summary>
		/// Closes the window on the press of the matching button.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickClose(object? sender, RoutedEventArgs e) => Close();

	}

}
