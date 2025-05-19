Imports System
Imports System.Formats
Imports System.IO


''' <summary>
''' The documentation program itself.
''' </summary>
Module Program
	''' <summary>
	''' The root directory for the documentation.
	''' </summary>
	Const ROOT_DOCS_DIR As String = "Documentation"

	''' <summary>
	''' The output directory.
	''' </summary>
	Const OUTPUT_DIR As String = "Output"

	Sub Main(args As String())
		Dim format As OutputFormat

		Console.Beep()
		Console.WriteLine("[WARNING] This program requires Emacs (recommended version: 30.1). Make sure it's on PATH.")
		Console.WriteLine("Press any key to continue or 'q' to abort...")

		Dim key As ConsoleKeyInfo
		key = Console.ReadKey(True)

		' Q has been pressed
		If key.Key = ConsoleKey.Q Then
			Console.Beep()
			Console.WriteLine("Aborting...")
			Environment.Exit(1) ' aborting
		End If

		' Output exists
		If Directory.Exists("Output") Then
			Directory.Delete("Output", True) ' get rid of Output if it already exists
		End If

		Directory.CreateDirectory("Output")
		MapOutputDirectory()

		Select Case args.Length
			Case 0
				format = OutputFormat.HTML
			Case 1
				Select Case args(0)
					Case "pdf", "latex", "x", "l", "t", "p"
						format = OutputFormat.LaTeX
					Case "md", "m", "mdown", "markdown"
						format = OutputFormat.Markdown
					Case Else
						format = OutputFormat.HTML
				End Select
			Case Else
				Console.Beep()
				Console.WriteLine("Usage: [FORMAT]")
				Console.WriteLine("Format may be pdf, latex, x, l, t or p (PDF), md, m, mdown, markdown (Markdown) or anything else (HTML).")
				Environment.Exit(2)
		End Select

		For Each submodule In Directory.GetDirectories(ROOT_DOCS_DIR)
			BuildDocumentationModule(submodule, format)
		Next

		For Each file In Directory.GetFiles(ROOT_DOCS_DIR)
			BuildDocumentationFile(file, format)
		Next
	End Sub

	Function RemoveFirstSegmentOfPath(fullPath As String) As String
		Try
			Dim parts As String() = fullPath.Split(Path.DirectorySeparatorChar)
			Return If(parts.Length > 1, String.Join(Path.DirectorySeparatorChar, parts, 1, parts.Length - 1), Nothing)
		Catch ex As Exception
			Console.WriteLine("[ERROR] Failed to normalize path. Ignoring file for safety reasons...")
			Return Nothing
		End Try
	End Function

	Sub MapOutputDirectory(Optional remnant As String = ROOT_DOCS_DIR)
		If remnant = Nothing Then
			remnant = ROOT_DOCS_DIR
		End If


		For Each moduleName In Directory.GetDirectories(remnant)
			Console.WriteLine($"Mapping {moduleName}...")

			Try
				Directory.CreateDirectory(Path.Join(OUTPUT_DIR, RemoveFirstSegmentOfPath(moduleName)))
			Catch ex As Exception
				Console.WriteLine($"[ERROR] Failed to map module of name {moduleName}.")
				Return
			End Try

			MapOutputDirectory(moduleName)
		Next
	End Sub

	Sub BuildDocumentationModule(moduleName As String, format As OutputFormat)
		If moduleName Is Nothing Then
			Console.WriteLine("[ERROR] Failed to build module!")
			Return
		End If

		For Each submodule In Directory.GetDirectories(moduleName)
			BuildDocumentationModule(submodule, format)
		Next

		For Each file In Directory.GetFiles(moduleName)
			BuildDocumentationFile(file, format)
		Next

	End Sub

	Sub BuildDocumentationFile(file As String, format As OutputFormat)
		If file Is Nothing Then
			Console.WriteLine($"[ERROR] Failed to build file at {file}!")
			Return
		End If

		If Not file.ToLower().EndsWith(".org") Then
			Console.WriteLine($"[WARNING] Skipping non-documentation file at {file}.")
			Return
		End If

		RunEmacs(file, format)
	End Sub

	Sub RunEmacs(fileToBuild As String, format As OutputFormat)
		Dim emacsFunction As String
		Dim outputFile As String
		Dim processX As Process = Nothing

		Select Case format
			Case OutputFormat.Markdown
				emacsFunction = "org-md-export-to-markdown"
				outputFile = fileToBuild.Substring(0, fileToBuild.Length - 4) & ".md"
			Case OutputFormat.LaTeX
				emacsFunction = "org-latex-export-to-pdf"
				outputFile = fileToBuild.Substring(0, fileToBuild.Length - 4) & ".pdf"
			Case Else
				emacsFunction = "org-html-export-to-html"
				outputFile = fileToBuild.Substring(0, fileToBuild.Length - 4) & ".html"
		End Select

		Try
			Dim psi As New ProcessStartInfo() With {
				.FileName = "emacs",
				.Arguments = $"--batch {fileToBuild} -f {emacsFunction}"
			}
			processX = Process.Start(psi)
			Console.WriteLine($"Building {fileToBuild} with Emacs...")

			processX.WaitForExit()

			If processX.ExitCode <> 0 Then
				Console.WriteLine("Emacs exited with a non-zero error code.")
				Throw New Exception()
			End If
		Catch ex As Exception
			Console.WriteLine($"[ERROR] Failed to build {fileToBuild} with Emacs.")
		End Try

		' Now, let's move them filessss
		If processX Is Nothing Then
			Console.WriteLine("[ERROR] Failed to move converted file to destination.")
			Return
		End If

		If processX.HasExited Then
			Try
				File.Move(outputFile, outputFile.Replace("Documentation", "Output"))
				Console.WriteLine("Moved file to destination.")
			Catch ex As Exception
				Console.WriteLine("[ERROR] Failed to move converted file to destination.")
			End Try
		End If
	End Sub

End Module
