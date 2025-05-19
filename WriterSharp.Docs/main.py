import sys
import os
import subprocess


output_format: str = "HTML"
emacs_on_path: str = "Unsure."


def is_emacs_on_path():
	process: subprocess.CompletedProcess | None = None

	try:
		process = subprocess.run(["emacs", "--version"], capture_output=True, text=True)

	except Exception:
		return False

	if process is None:
		return False

	if process.returncode != 0:
		return False

	return True


def show_build_screen():
	global output_format, emacs_on_path

	os.system('cls' if sys.platform == 'win32' else 'clear')
	print("""WriterSharp.Docs
====================
OUTPUT_FORMAT = {0}
Emacs on PATH? {1}
====================
[1] Build Documentation with format OUTPUT_FORMAT
[2] Check if Emacs is on PATH
[3] Set OUTPUT_FORMAT to HTML
[4] Set OUTPUT_FORMAT to PDF (requires LaTeX)
[5] Set OUTPUT_FORMAT to Markdown
[0] Exit
""".format(output_format, emacs_on_path))
	
	action: str = input("Your input: ")

	if not action.isdigit():
		print("Aborting...")
		sys.exit(1) # wrong option

	if action not in ('1', '2', '3', '4', '5'):
		print("Aborting...")
		sys.exit(1)

	if action == "3":
		output_format = "HTML"
	
	if action == "4":
		output_format = "PDF"

	if action == "5":
		output_format = "Markdown"

	if action == "2":
		if is_emacs_on_path():
			emacs_on_path = "Yes."

		else:
			emacs_on_path = "No."

	if action == "1":
		try:
			subprocess.run([f"{'./' if sys.platform != 'win32' else ''}WriterSharp.Docs{'.exe' if sys.platform == 'win32' else ''}", output_format.lower()], text=True)

		except Exception:
			print("Error! Failed to load WriterSharp.Docs. Are you sure you're running this script in the same folder as the executable?\nAborting...")
			sys.exit(2)

	show_build_screen()


if __name__ == '__main__':
	print("Requirements:\n- Emacs\n- WriterSharp.Docs in the same directory\n")
	input("Press any key to continue...")
	show_build_screen()
