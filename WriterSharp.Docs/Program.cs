using System;
using System.Diagnostics;
using System.IO;


namespace WriterSharp.Docs
{

	internal class Program
	{

		static void Main(string[] args)
		{

			ConsoleKeyInfo key;
			ConversionProgram convProgram;
			DocsFormat outFormat;

			switch (args.Length)
			{

				case 0:
					Console.Write("Make sure you have Emacs installed and on PATH. Press any key to continue (q to abort)... [");
					key = Console.ReadKey();

					if (key.Key == ConsoleKey.Q)
					{

						Console.WriteLine("]\nAborted.");
						Environment.Exit(1);

					}

					if (Directory.Exists("Output"))
					{

						Directory.Delete("Output", true);

					}

					Directory.CreateDirectory("Output");

					foreach (var module in Directory.GetDirectories("Documentation"))
					{

						Directory.CreateDirectory(Path.Join("Output", Path.GetFileName(module)));
						BuildDocumentationModule(module, DocsFormat.HTML, ConversionProgram.Emacs);

					}

					foreach (var file in Directory.GetFiles("Documentation"))
					{

						BuildDocumentationFile(file, DocsFormat.HTML, ConversionProgram.Emacs);

					}

					break;

				case 1:
					convProgram = args[0] switch
					{

						"pandoc" or "pd" or "Pandoc" => ConversionProgram.Pandoc,
						_ => ConversionProgram.Emacs

					};

					if (Directory.Exists("Output"))
					{

						Directory.Delete("Output", true);

					}

					Directory.CreateDirectory("Output");

					foreach (var module in Directory.GetDirectories("Documentation"))
					{

						Directory.CreateDirectory(Path.Join("Output", Path.GetFileName(module)));
						BuildDocumentationModule(module, DocsFormat.HTML, convProgram);

					}

					foreach (var file in Directory.GetFiles("Documentation"))
					{

						BuildDocumentationFile(file, DocsFormat.HTML, convProgram);

					}

					break;

				case 2:
					convProgram = args[0] switch
					{

						"pandoc" or "pd" or "Pandoc" => ConversionProgram.Pandoc,
						_ => ConversionProgram.Emacs

					};

					outFormat = args[1] switch
					{

						"pdf" or "latex" => DocsFormat.PDFLatex,
						"markdown" or "md" or "mdown" => DocsFormat.Markdown,
						_ => DocsFormat.HTML

					};

					if (Directory.Exists("Output"))
					{

						Directory.Delete("Output", true);

					}

					Directory.CreateDirectory("Output");

					foreach (var module in Directory.GetDirectories("Documentation"))
					{

						Directory.CreateDirectory(Path.Join("Output", Path.GetFileName(module)));
						BuildDocumentationModule(module, outFormat, convProgram);

					}

					foreach (var file in Directory.GetFiles("Documentation"))
					{

						BuildDocumentationFile(file, outFormat, convProgram);

					}

					break;

				case 3:
					convProgram = args[0] switch
					{

						"pandoc" or "pd" or "Pandoc" => ConversionProgram.Pandoc,
						_ => ConversionProgram.Emacs

					};

					outFormat = args[1] switch
					{

						"pdf" or "latex" => DocsFormat.PDFLatex,
						"markdown" or "md" or "mdown" => DocsFormat.Markdown,
						_ => DocsFormat.HTML

					};

					if (Directory.Exists("Output"))
					{

						Directory.Delete("Output", true);

					}

					Directory.CreateDirectory("Output");

					if (!Directory.Exists(Path.Join("Documentation", args[2])))
					{

						Console.WriteLine($"[ERROR] Couldn't find module {args[2]}.");

					}

					Directory.CreateDirectory(Path.Join("Output", args[2]));
					BuildDocumentationModule(Path.Join("Documentation", args[2]), outFormat, convProgram);
					break;

				default:
					Console.WriteLine("Usage: [<pandoc|pd|Pandoc|emacs|...>] [<pdf|latex|markdown|mdown|md|(html)|...>] [MODULE]");
					Console.WriteLine("Description: [PROGRAM] [FORMAT] [MODULE]");
					Console.WriteLine("Defaults to: Emacs html (builds-all)");
					Environment.Exit(2);
					break;

			}

		}

		private static void BuildDocumentationModule(string? directory, DocsFormat outputFormat, ConversionProgram conversionProgram)
		{

			if (directory is null)
			{

				Console.WriteLine("[ERROR] Failed to build module!");
				return;

			}

			foreach (var submodule in Directory.GetDirectories(directory))
			{

				Directory.CreateDirectory(Path.Join("Output", Path.GetFileName(directory), Path.GetFileName(submodule)));
				BuildDocumentationModule(submodule, outputFormat, conversionProgram);

			}

			foreach (var file in Directory.GetFiles(directory))
			{

				BuildDocumentationFile(file, outputFormat, conversionProgram);

			}

		}

		private static void BuildDocumentationFile(string? file, DocsFormat outputFormat, ConversionProgram conversionProgram)
		{

			if (file is null)
			{

				Console.WriteLine($"[ERROR] Failed to build file at {file}!");
				return;

			}

			if (!file.ToLower().EndsWith(".org"))
			{

				Console.WriteLine($"[WARNING] Skipping non-documentation file: {file}.");
				return;

			}

			switch (conversionProgram)
			{

				case ConversionProgram.Pandoc:
					RunPandoc(file, outputFormat);
					break;

				default:
					RunEmacs(file, outputFormat);
					break;

			}
			
		}

		private static void RunEmacs(string file, DocsFormat outputFormat)
		{

			file = Path.GetFullPath(file, AppContext.BaseDirectory);

			string command = outputFormat switch
			{

				DocsFormat.Markdown => $"--batch {file} -f org-md-export-to-markdown",
				DocsFormat.PDFLatex => $"--batch {file} -f org-latex-export-to-pdf",
				_ => $"--batch {file} -f org-html-export-to-html",

			};

			string outputFile = outputFormat switch
			{

				DocsFormat.Markdown => $"{file.AsSpan(0, file.Length - 4).ToString()}.md",
				DocsFormat.PDFLatex => $"{file.AsSpan(0, file.Length - 4).ToString()}.pdf",
				_ => $"{file.AsSpan(0, file.Length - 4).ToString()}.html",

			};

			Process? process = null;

			try
			{

				ProcessStartInfo psi = new()
				{

					FileName = "emacs",
					Arguments = command,
					UseShellExecute = true

				};
				process = Process.Start(psi);
				Console.WriteLine($"Built {file} successfully using Emacs!");
				process!.WaitForExit();

			}
			catch (Exception ex)
			{

				Console.WriteLine($"Exception occured while building {file} with Emacs: {ex.Message ?? "Unknown Error"}");

			}

			if (process?.HasExited ?? true)
			{

				try
				{

					File.Move(outputFile, outputFile.Replace("Documentation", "Output"));
					Console.WriteLine("Moved file to destination.");

				}
				catch (Exception)
				{

					Console.WriteLine("[ERROR] Failed to move converted file to destination.");

				}

			}

		}

		private static void RunPandoc(string file, DocsFormat outputFormat)
		{

			file = Path.GetFullPath(file, AppContext.BaseDirectory);

			string command = outputFormat switch
			{

				DocsFormat.Markdown => $"{file} -f org -t markdown -o {file.AsSpan(0, file.Length - 4).ToString().Replace("Documentation", "Output")}.md",
				DocsFormat.PDFLatex => $"{file} -f org -o {file.AsSpan(0, file.Length - 4).ToString().Replace("Documentation", "Output")}.pdf",
				_ => $"{file} -f org -t html -o {file.AsSpan(0, file.Length - 4).ToString().Replace("Documentation", "Output")}.html",
			
			};

			try
			{

				ProcessStartInfo psi = new()
				{

					FileName = "pandoc",
					Arguments = command,
					UseShellExecute = true

				};
				Process.Start(psi);
				Console.WriteLine($"Built {file} successfully using Pandoc!");

			}
			catch (Exception ex)
			{

				Console.WriteLine($"Exception occured while building {file} with Pandoc: {ex.Message ?? "Unknown Error"}");

			}

		}

	}

}
