import sys
import os
import subprocess
import random

# colorsss
ASCII_COLOR: str = random.choice((f"\033[{random.randint(30, 37)}m",
								  f"\033[{random.randint(90, 97)}m"))
RED = "\033[31m"
GREEN = "\033[32m"
YELLOW = "\033[33m"
BLUE = "\033[34m"
MAGENTA = "\033[35m"
CYAN = "\033[36m"
RESET = "\033[0m"

STATUS_COLORS: dict[str, str] = {
	"Yes.": GREEN,
	"No.": RED,
	"Unsure.": YELLOW
}

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
	print(f"""              ___       __   ________  ___  _________  _______   ________  ________  ___  ___  ________  ________  ________        ________  ________  ________  ________                  
             |\  \     |\  \|\   __  \|\  \|\___   ___\\  ___ \ |\   __  \|\   ____\|\  \|\  \|\   __  \|\   __  \|\   __  \      |\   ___ \|\   __  \|\   ____\|\   ____\                 
  ___        \ \  \    \ \  \ \  \|\  \ \  \|___ \  \_\ \   __/|\ \  \|\  \ \  \___|\ \  \\\  \ \  \|\  \ \  \|\  \ \  \|\  \     \ \  \_|\ \ \  \|\  \ \  \___|\ \  \___|_            ___ 
 |\__\        \ \  \  __\ \  \ \   _  _\ \  \   \ \  \ \ \  \_|/_\ \   _  _\ \_____  \ \   __  \ \   __  \ \   _  _\ \   ____\     \ \  \ \\ \ \  \\\  \ \  \    \ \_____  \          |\__\
 \|__|         \ \  \|\__\_\  \ \  \\  \\ \  \   \ \  \ \ \  \_|\ \ \  \\  \\|____|\  \ \  \ \  \ \  \ \  \ \  \\  \\ \  \___|      \ \  \_\\ \ \  \\\  \ \  \____\|____|\  \         \|__|
                \ \____________\ \__\\ _\\ \__\   \ \__\ \ \_______\ \__\\ _\ ____\_\  \ \__\ \__\ \__\ \__\ \__\\ _\\ \__\          \ \_______\ \_______\ \_______\____\_\  \             
                 \|____________|\|__|\|__|\|__|    \|__|  \|_______|\|__|\|__|\_________\|__|\|__|\|__|\|__|\|__|\|__|\|__|           \|_______|\|_______|\|_______|\_________\            
                                                                             \|_________|                                                                          \|_________|            
                                                                                                                                                                                           

Copyright (c) 2025 MF366{RESET}
====================
{YELLOW}Output format set to:{RESET} {output_format}
Emacs on PATH? {STATUS_COLORS[emacs_on_path]}{emacs_on_path}{RESET}
====================
[1] Build Documentation with format OUTPUT_FORMAT
[2] Check if Emacs is on PATH
[3] Set output format to HTML
[4] Set output format to PDF (requires LaTeX)
[5] Set output format to Markdown
[0] Exit
""")
	
	action: str = input(f"{CYAN}Your input: {RESET}")

	if not action.isdigit():
		print(f"{RED}Aborting...{RESET}")
		sys.exit(1) # wrong option

	if action not in ('1', '2', '3', '4', '5'):
		print(f"{RED}Aborting...{RESET}")
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
			print(f"{RED}Error! Failed to load WriterSharp.Docs. Are you sure you're running this script in the same folder as the executable?\nAborting...{RESET}")
			sys.exit(2)

	show_build_screen()


if __name__ == '__main__':
	print(f"{MAGENTA}Requirements:{RESET}\n {GREEN}[x] Emacs\n [x] WriterSharp.Docs in the same directory\n{RESET}")
	input("Press any key to continue...")
	show_build_screen()
