/*
 *  __  __          _           __      __  _             _                
 * |  \/  |  __ _  (_)  _ _     \ \    / / (_)  _ _    __| |  ___  __ __ __
 * | |\/| | / _` | | | | ' \     \ \/\/ /  | | | ' \  / _` | / _ \ \ V  V /
 * |_|  |_| \__,_| |_| |_||_|     \_/\_/   |_| |_||_| \__,_| \___/  \_/\_/ 
 *          
 * MIT License * MF366
 *          
 */


// System
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// Avalonia
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using Avalonia.Win32.Interop.Automation;


// Message Box
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Models;

// Internal
using WriterSharp.Browser;


namespace WriterSharp
{

    /// <summary>
    /// Handles everything related to the main window.
    /// </summary>
    public partial class MainWindow : Window
    {

		Assembly currentAssembly = Assembly.GetExecutingAssembly();
		string? currentFile = null;
		bool hasBeenModified = false;
		readonly string appName;
		readonly string appVersion;
		readonly string[] appVersionValues;
		const string REPOSITORY_URL = "https://github.com/MF366-Coding/WriterSharp";
		const string WEBSITE_URL = "https://mf366-coding.github.io/writersharp.html";

		/// <summary>
		/// The WriterSharp encoding to use. Defaults to UTF-8.
		/// </summary>
		Encoding encoding = Encoding.UTF8;

		/// <summary>
		/// Custom message box parameters for errors.
		/// </summary>
		MessageBoxCustomParams errorMessageParams = new()
		{

			ButtonDefinitions = new List<ButtonDefinition>
				{

					new() { Name = "Ok", IsDefault = true }

				},
			Icon = MsBox.Avalonia.Enums.Icon.Error,
			WindowStartupLocation = WindowStartupLocation.CenterOwner,
			CanResize = false,
			MaxWidth = 500,
			MaxHeight = 800,
			SizeToContent = SizeToContent.WidthAndHeight,
			ShowInCenter = true,
			Topmost = true

		};

		public MainWindow()
        {

			appName = currentAssembly.GetCustomAttribute<AssemblyTitleAttribute>()!.Title;
			appVersion = currentAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;
			appVersionValues = appVersion.Split('.');
			InitializeComponent();

        }

		private async Task<string> ShowError(string title, string contents)
		{

			errorMessageParams.ContentTitle = title;
			errorMessageParams.ContentMessage = contents;

			var messageBox = MessageBoxManager.GetMessageBoxCustom(errorMessageParams);
			return await messageBox.ShowAsync();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnContentModification(object? sender, TextChangedEventArgs e)
		{

			if (!hasBeenModified)
			{

				hasBeenModified = true;
				((TextBox)sender!).TextChanged -= OnContentModification;

			}

		}


		private async void OnClickOpen(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{

			List<FilePickerFileType> allowedFiletypes = [FilePickerFileTypes.TextPlain];

			// Start async operation to open the dialog.
			var filepath = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
			{

				Title = "Open...",
				AllowMultiple = false,
				FileTypeFilter = [FilePickerFileTypes.All]

			});

			if (filepath.Count >= 1)
			{

				await using var stream = await filepath[0].OpenReadAsync();
				string? fileContents;

				try
				{

					using var streamReader = new StreamReader(stream, true);
					fileContents = await streamReader.ReadToEndAsync();
					fileContents.ReplaceLineEndings();

				}
				catch (Exception)
				{

					await ShowError("Failed to open file", "Are you sure the file you selected is a plain text file?");
					return;

				}				

				var textBox = this.FindControl<TextBox>("MainTextBox");
				textBox!.Text = fileContents;

			}

		}

		private async void OnClickRepository(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{

			await BrowserService.OpenURLAsync(REPOSITORY_URL);

		}

		private async void OnClickWebsite(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{

			await BrowserService.OpenURLAsync(WEBSITE_URL);

		}

		private void OnClickNewFromScratch(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
		{
			// TODO
		}

		private void OnClickExit(object? sender = null, Avalonia.Interactivity.RoutedEventArgs? e = null)
		{

			// TODO
			if (!hasBeenModified)
			{

				Close();

			}

		}

		private void OnClickExitWithoutSaving(object? sender = null, Avalonia.Interactivity.RoutedEventArgs? e = null)
		{

			Close();

		}

	}

}
