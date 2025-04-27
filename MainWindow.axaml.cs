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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// Avalonia
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using AvaloniaEdit;

// Message Box
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;

// Internal
using WriterSharp.Browser;


namespace WriterSharp
{

	// TODO: add locale settings and support
	// TODO: add sidebar
	// TODO: add plugin support
	// TODO: add "Export"
	// TODO: add About stuff
	// TODO: add markdown and org mode tools

	/// <summary>
	/// Handles everything related to the main window.
	/// </summary>
	public partial class MainWindow : Window
	{

		#region Fields

		/// <summary>
		/// The line ending mode to use.
		/// </summary>
		readonly string lineEndingMode;

		/// <summary>
		/// The current Assembly.
		/// </summary>
		readonly Assembly currentAssembly = Assembly.GetExecutingAssembly();

		/// <summary>
		/// The current filepath.
		/// </summary>
		string? currentFile = null;

		/// <summary>
		/// WriterSharp.
		/// </summary>
		readonly string appName;

		/// <summary>
		/// WriterSharp's version.
		/// </summary>
		readonly string appVersion;

		/// <summary>
		/// WriterSharp's version, but split into an array:
		/// <code>{ MAJOR, MINOR, PATCH }</code>
		/// </summary>
		readonly string[] appVersionValues;

		/// <summary>
		/// The URL to WriterSharp's repository.
		/// </summary>
		const string REPOSITORY_URL = "https://github.com/MF366-Coding/WriterSharp";

		/// <summary>
		/// The URL to WriterSharp's website.
		/// </summary>
		const string WEBSITE_URL = "https://mf366-coding.github.io/writersharp.html";

		/// <summary>
		/// The WriterSharp encoding to use. Defaults to UTF-16.
		/// </summary>
		readonly Encoding defaultEncoding = Encoding.Unicode;

		/// <summary>
		/// Custom message box parameters for errors.
		/// </summary>
		readonly MessageBoxCustomParams errorMessageParams = new()
		{

			ButtonDefinitions =
				[

					new() { Name = "Ok", IsDefault = true, IsCancel = true }

				],
			Icon = MsBox.Avalonia.Enums.Icon.Error,
			WindowStartupLocation = WindowStartupLocation.CenterOwner,
			CanResize = false,
			MaxWidth = 500,
			MaxHeight = 800,
			SizeToContent = SizeToContent.WidthAndHeight,
			ShowInCenter = true,
			Topmost = true

		};

		/// <summary>
		/// Custom message box parameters for a Yes/No/Cancel question.
		/// </summary>
		readonly MessageBoxCustomParams questionYesNoCancelParams = new()
		{

			ButtonDefinitions =
				[

					new() { Name = "Yes", IsDefault = true },
					new() { Name = "No" },
					new() { Name = "Cancel", IsCancel = true }

				],
			Icon = MsBox.Avalonia.Enums.Icon.Question,
			WindowStartupLocation = WindowStartupLocation.CenterOwner,
			CanResize = false,
			MaxWidth = 500,
			MaxHeight = 800,
			SizeToContent = SizeToContent.WidthAndHeight,
			ShowInCenter = true,
			Topmost = true

		};

		#endregion

		#region UI Components

		/// <summary>
		/// WriterSharp's code editor.
		/// </summary>
		readonly TextEditor textEditor;

		/// <summary>
		/// Indicator for whether the file has been modified or not.
		/// </summary>
		readonly TextBlock modifiedIndicator;

		/// <summary>
		/// Indicator for currently used encoding.
		/// </summary>
		readonly TextBlock encodingIndicator;

		/// <summary>
		/// Indicator for currenty used line ending.
		/// </summary>
		readonly TextBlock lineEndingIndicator;

		/// <summary>
		/// Indicator for currently used language.
		/// </summary>
		readonly TextBlock languageIndicator;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes the main window.
		/// </summary>
		public MainWindow()
		{

			// assigning some fields
			appName = currentAssembly.GetCustomAttribute<AssemblyTitleAttribute>()!.Title;
			appVersion = currentAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;
			appVersionValues = appVersion.Split('.');

			// initialization
			InitializeComponent();

			#if WINDOWS
				lineEndingMode = "CRLF";

			#else
				lineEndingMode = "LF";

			#endif

			textEditor = this.FindControl<TextEditor>("MainCodeEditor")!;

			encodingIndicator = this.FindControl<TextBlock>("EncInd")!;
			languageIndicator = this.FindControl<TextBlock>("LangInd")!;
			lineEndingIndicator = this.FindControl<TextBlock>("LEnInd")!;
			modifiedIndicator = this.FindControl<TextBlock>("ModInd")!;

			CreateNewFileFromScratch();

		}

		#endregion

		#region MessageBox Display Methods

		/// <summary>
		/// Shows an error to the screen.
		/// </summary>
		/// <param name="title">The error title</param>
		/// <param name="contents">The error message</param>
		/// <returns></returns>
		private async Task<string> ShowError(string title, string contents)
		{

			errorMessageParams.ContentTitle = title;
			errorMessageParams.ContentMessage = contents;

			var messageBox = MessageBoxManager.GetMessageBoxCustom(errorMessageParams);
			return await messageBox.ShowAsync();

		}

		/// <summary>
		/// Shows a question with Yes/No/Cancel buttons.
		/// </summary>
		/// <param name="title">The dialog box title</param>
		/// <param name="contents">The question</param>
		/// <returns>The label of the button that was clicked.</returns>
		private async Task<string> ShowYesNoQuestion(string title, string contents)
		{

			questionYesNoCancelParams.ContentTitle = title;
			questionYesNoCancelParams.ContentMessage = contents;

			var messageBox = MessageBoxManager.GetMessageBoxCustom(questionYesNoCancelParams);
			return await messageBox.ShowAsync();

		}

		#endregion

		#region New Files

		/// <summary>
		/// Does the actual creation of files from scratch.
		/// </summary>
		private void CreateNewFileFromScratch()
		{

			ResetCodeEditorAttributes(String.Empty, defaultEncoding);
			ResetFooterIndicators(
				"Plain Text",
				"WriterSharp",
				defaultEncoding,
				lineEndingMode,
				false
			);
			currentFile = null;
			UpdateWindowTitleToMatchNameFilePattern();

		}

		/// <summary>
		/// Handles the creation of new files from scratch.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OnClickNewFromScratch(object? sender, RoutedEventArgs e)
		{

			var userChoice = await CheckForModifications("Do you want to save your changes before creating a new file?");
			int retCode;

			switch (userChoice)
			{

				case "No": // No modifications or user chose "no"
					CreateNewFileFromScratch();
					break;

				case "Yes":
					if (currentFile is null)
					{

						var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
						{

							Title = "Save...",
							ShowOverwritePrompt = true,
							FileTypeChoices = [FilePickerFileTypes.All],
							SuggestedFileName = "My_Amazing_File",
							DefaultExtension = "txt"

						});

						if (file is not null)
						{

							retCode = await SaveFile(file);

						}

						else
						{

							retCode = 1;

						}

					}

					else
					{

						retCode = await SaveFile(currentFile);

					}
					
					if (retCode == 0)
					{

						CreateNewFileFromScratch();

					}

					break;

				default:
					break; // do nothing

			}

		}

		// TODO: add "New from template"

		#endregion

		#region Opening Files

		/// <summary>
		/// Opens a file given a string representing a path to it.
		/// </summary>
		/// <param name="filepath">The file to open, as a string</param>
		/// <returns></returns>
		private async Task OpenFile(string filepath)
		{

			try
			{

				var fileContent = await File.ReadAllTextAsync(filepath, defaultEncoding);

				ResetCodeEditorAttributes(fileContent, defaultEncoding);
				ResetFooterIndicators("Plain Text", "WriterSharp Essentials", defaultEncoding, lineEndingMode, false); // TODO: add language and plugin support
				currentFile = filepath;
				UpdateWindowTitleToMatchNameFilePattern();

			}
			catch (Exception)
			{

				await ShowError("Failed to open file", "An unknown error occured while attempting to open the selected file.");

			}

		}

		/// <summary>
		/// Opens a file given a filepath in the form of IStorageFile.
		/// </summary>
		/// <param name="file">The file to open</param>
		/// <returns></returns>
		private async Task OpenFile(IStorageFile file)
		{

			try
			{

				await using var stream = await file.OpenReadAsync();
				using var streamReader = new StreamReader(stream, true);
				var fileContent = await streamReader.ReadToEndAsync();
				fileContent = fileContent.ReplaceLineEndings();

				ResetCodeEditorAttributes(fileContent, streamReader.CurrentEncoding);
				ResetFooterIndicators("Plain Text", "WriterSharp Essentials", streamReader.CurrentEncoding, lineEndingMode, false); // TODO: add language and plugin support
				currentFile = file.TryGetLocalPath();
				UpdateWindowTitleToMatchNameFilePattern();

			}
			catch (Exception)
			{

				await ShowError("Failed to open file", "An unknown error occured while attempting to open the selected file.");

			}

		}

		/// <summary>
		/// handles the "Click on Open File" event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OnClickOpenFile(object? sender, RoutedEventArgs e)
		{

			var userChoice = await CheckForModifications("Do you want to save your changes before creating a new file?");
			int retCode;
			IReadOnlyList<IStorageFile>? files;

			switch (userChoice)
			{

				case "No": // No modifications or user chose "no"
					files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
					{

						Title = "Open...",
						AllowMultiple = false,
						FileTypeFilter = [FilePickerFileTypes.All]

					});

					if (files is null) return; // do nothing

					if (files.Count >= 1)
					{

						await OpenFile(files[0]);

					}
					break;

				case "Yes":
					if (currentFile is null)
					{

						var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
						{

							Title = "Save...",
							ShowOverwritePrompt = true,
							FileTypeChoices = [FilePickerFileTypes.All],
							SuggestedFileName = "My_Amazing_File",
							DefaultExtension = "txt"

						});

						if (file is not null)
						{

							retCode = await SaveFile(file);

						}

						else
						{

							retCode = 1;

						}

					}

					else
					{

						retCode = await SaveFile(currentFile);

					}

					if (retCode == 0)
					{

						files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
						{

							Title = "Open...",
							AllowMultiple = false,
							FileTypeFilter = [FilePickerFileTypes.All]

						});

						if (files is null) return; // do nothing

						if (files.Count >= 1)
						{

							await OpenFile(files[0]);

						}

					}

					break;

				default:
					break; // do nothing

			}

		}

		// TODO: add "Open recent" feature

		#endregion

		#region Saving Files

		/// <summary>
		/// Saves a file given a path as string.
		/// </summary>
		/// <param name="filepath">The filepath in the form of a string</param>
		/// <returns>0 if successful, 1 if an error occured</returns>
		private async Task<int> SaveFile(string filepath)
		{

			try
			{

				await File.WriteAllTextAsync(filepath, textEditor.Text, textEditor.Encoding);

				ResetCodeEditorAttributes(null, null);
				ResetFooterIndicators("Plain Text", "WriterSharp Essentials", textEditor.Encoding, lineEndingMode, false); // TODO: add language and plugin support
				currentFile = filepath;
				UpdateWindowTitleToMatchNameFilePattern();
				return 0;

			}
			catch (Exception)
			{

				await ShowError("Failed to save", "An unknown error occured while attempting to save the current file.");
				return 1;

			}

		}

		/// <summary>
		/// Saves a file given a IStorageFile from an Avalonia FilePicker.
		/// </summary>
		/// <param name="file">The file to write to</param>
		/// <returns>0 if successful, 1 if an error occured</returns>
		private async Task<int> SaveFile(IStorageFile file)
		{

			try
			{

				await using var stream = await file.OpenWriteAsync();
				using var streamWriter = new StreamWriter(stream, textEditor.Encoding);
				await streamWriter.WriteLineAsync(textEditor.Text.ReplaceLineEndings());

				ResetCodeEditorAttributes(null, null);
				ResetFooterIndicators("Plain Text", "WriterSharp Essentials", textEditor.Encoding, lineEndingMode, false); // TODO: add language and plugin support
				currentFile = file.TryGetLocalPath();
				UpdateWindowTitleToMatchNameFilePattern();
				return 0;

			}
			catch (Exception)
			{

				await ShowError("Failed to save", "An unknown error occured while attempting to save the current file.");
				return 1;

			}
			
		}

		/// <summary>
		/// Handles "Click on Save File" event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OnClickSaveFile(object? sender, RoutedEventArgs e)
		{

			if (currentFile is null)
			{

				var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
				{

					Title = "Save...",
					ShowOverwritePrompt = true,
					FileTypeChoices = [FilePickerFileTypes.All],
					SuggestedFileName = "My_Amazing_File",
					DefaultExtension = "txt"

				});

				if (file is not null)
				{

					await SaveFile(file);

				}

			}

			else
			{

				await SaveFile(currentFile);

			}

		}

		/// <summary>
		/// Handles "Click on Save As" event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OnClickSaveAs(object? sender, RoutedEventArgs e)
		{

			var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
			{

				Title = "Save...",
				ShowOverwritePrompt = true,
				FileTypeChoices = [FilePickerFileTypes.All],
				SuggestedFileName = "My_Amazing_File",
				DefaultExtension = "txt"

			});

			if (file is not null)
			{

				await SaveFile(file);

			}

		}

		#endregion

		#region Handling WriterSharp Exit

		// TODO: add regular exit method
		// TODO: make the 'X' button follow the regular exit instead of being a destructive exit

		/// <summary>
		/// Exits WriterSharp without asking for confirmation.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClickExitWithoutSaving(object? sender = null, Avalonia.Interactivity.RoutedEventArgs? e = null) => Close();

		#endregion

		#region Helper Methods

		/// <summary>
		/// Resets the code editor's attributes.
		/// </summary>
		/// <param name="code">The code/text to place in the editor</param>
		/// <param name="encoding">The encoding to use</param>
		private void ResetCodeEditorAttributes(string? code = null, Encoding? encoding = null)
		{

			textEditor.TextChanged += UpdateModifiedIndicator;
			textEditor.Text = code ?? textEditor.Text;
			textEditor.Encoding = encoding ?? textEditor.Encoding;
			textEditor.IsModified = false;

		}

		/// <summary>
		/// Resets WriterSharp's footer indicators and rebinds removed hooks (if applicable).
		/// </summary>
		/// <param name="language">The language of the file</param>
		/// <param name="languagePluginName">The plugin that's managing the currently loaded language</param>
		/// <param name="encoding">The encoding that's being used</param>
		/// <param name="lineEndingName">The name of the Line Ending Mode (LF, CRLF, CR)</param>
		/// <param name="isModified">Whether the file has been modified or not. If set to null, gets this property from the text editor</param>
		private void ResetFooterIndicators(string language, string languagePluginName, Encoding encoding, string lineEndingName, bool? isModified = null)
		{

			languageIndicator.Text = $"{language} (Managed by: {languagePluginName})";
			encodingIndicator.Text = encoding.EncodingName == "Unicode" ? "UTF-16" : encoding.EncodingName;
			lineEndingIndicator.Text = lineEndingName.ToUpperInvariant();

			isModified ??= textEditor.IsModified;

			modifiedIndicator.Text = (isModified == true) ? "*" : " ";
			textEditor.TextChanged += UpdateModifiedIndicator;

		}

		/// <summary>
		/// Updates the window title to match the APP_NAME - FILE_NAME pattern, but only if the file is saved.
		/// </summary>
		private void UpdateWindowTitleToMatchNameFilePattern()
		{

			if (currentFile is null) Title = "WriterSharp";
			else Title = $"WriterSharp - {currentFile}";

		}

		/// <summary>
		/// Checks for modifications. If there are any, shows a question with Yes/No/Cancel.
		/// </summary>
		/// <param name="message">The dialog box message to show</param>
		/// <returns></returns>
		private async Task<string> CheckForModifications(string message)
		{

			if (!textEditor.IsModified) return "No";
			return await ShowYesNoQuestion("File has been modified", message);

		}

		#endregion

		#region Secondary Events

		/// <summary>
		/// Dynamically update the "Modified" indicator in the footer.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateModifiedIndicator(object? sender, EventArgs e)
		{

			modifiedIndicator.Text = (textEditor.IsModified == true) ? "*" : " ";
			if (textEditor.IsModified) textEditor.TextChanged -= UpdateModifiedIndicator;

		}

		#endregion

		#region Misc. Events

		/// <summary>
		/// Opens WriterSharp's repo.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OnClickRepository(object? sender, RoutedEventArgs? e) => await BrowserService.OpenURLAsync(REPOSITORY_URL);

		/// <summary>
		/// Opens WriterSharp's website.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void OnClickWebsite(object? sender, RoutedEventArgs? e) => await BrowserService.OpenURLAsync(WEBSITE_URL);

		#endregion

	}

}
