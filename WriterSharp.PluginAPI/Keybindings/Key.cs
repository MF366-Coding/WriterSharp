namespace WriterSharp.PluginAPI.Keybindings
{

	/// <summary>
	/// The most commonly used keys as specified by Avalonia, but with certain name changes.
	/// </summary>
	public enum KeybindingKey
	{

		A = 44,
		Add = 85,
		ApplicationKey = 72,
		B = 45,
		Back = 2,
		BrowserBack = 122,
		BrowserBookmarks = 127,
		BrowserForward = 123,
		BrowserHome = 128,
		BrowserInterrupt = 125,
		BrowserRefresh = 124,
		BrowserSearch = 126,
		C = 46,
		Cancel = 1,

		/// <summary>
		/// CAPS LOCK.
		/// </summary>
		CapsLock = 8,
		Clear = 5,
		D = 47,

		/// <summary>
		/// Digit 0.
		/// </summary>
		Digit0 = 34,

		/// <summary>
		/// Digit 1.
		/// </summary>
		Digit1 = 35,

		/// <summary>
		/// Digit 2.
		/// </summary>
		Digit2 = 36,

		/// <summary>
		/// Digit 3.
		/// </summary>
		Digit3 = 37,

		/// <summary>
		/// Digit 4.
		/// </summary>
		Digit4 = 38,

		/// <summary>
		/// Digit 5.
		/// </summary>
		Digit5 = 39,

		/// <summary>
		/// Digit 6.
		/// </summary>
		Digit6 = 40,

		/// <summary>
		/// Digit 7.
		/// </summary>
		Digit7 = 41,

		/// <summary>
		/// Digit 8.
		/// </summary>
		Digit8 = 42,

		/// <summary>
		/// Digit 9.
		/// </summary>
		Digit9 = 43,
		DecimalKey = 88,

		/// <summary>
		/// DELETE.
		/// </summary>
		Delete = 32,
		Divide = 89,
		DownArrow = 26,
		E = 48,

		/// <summary>
		/// END.
		/// </summary>
		End = 21,
		Enter = 6,
		EraseEof = 166,

		/// <summary>
		/// ESC.
		/// </summary>
		Escape = 13,
		Execute = 29,
		F = 49,

		#region Function Keys
		F1 = 90,
		F2 = 91,
		F3 = 92,
		F4 = 93,
		F5 = 94,
		F6 = 95,
		F7 = 96,
		F8 = 97,
		F9 = 98,
		F10 = 99,
		F11 = 100,
		F12 = 101,
		F13 = 102,
		F14 = 103,
		F15 = 104,
		F16 = 105,
		F17 = 106,
		F18 = 107,
		F19 = 108,
		F20 = 109,
		F21 = 110,
		F22 = 111,
		F23 = 112,
		F24 = 113,
		#endregion

		G = 50,
		H = 51,
		Help = 33,
		Home = 22,
		I = 52,

		/// <summary>
		/// INS.
		/// </summary>
		Insert = 31,
		J = 53,
		K = 54,
		L = 55,
		LaunchApp1 = 138,
		LaunchApp2 = 139,
		LaunchMail = 136,
		LeftArrow = 23,
		LeftAlt = 120,
		LeftControl = 118,
		LeftShift = 116,
		LMeta = 70,
		M = 56,
		MediaNext = 132,
		MediaPrevious = 133,
		MediaStop = 134,
		MediaTogglePlayStatus = 135,
		Multiply = 84,
		N = 57,

		/// <summary>
		/// 'None' in Avalonia's Key enum.
		/// Corresponds to the lack of a key press.
		/// </summary>
		NoKeyPressed = 0,
		NumLock = 114,
		NumPad0 = 74,
		NumPad1 = 75,
		NumPad2 = 76,
		NumPad3 = 77,
		NumPad4 = 78,
		NumPad5 = 79,
		NumPad6 = 80,
		NumPad7 = 81,
		NumPad8 = 82,
		NumPad9 = 83,
		O = 58,
		P = 59,
		PageDown = 20,
		PageUp = 19,
		Pause = 7,
		Play = 167,
		Print = 28,
		PrintScreen = 30,
		Q = 60,
		R = 61,
		RightAlt = 121,
		RightArrow = 25,
		RightControl = 119,
		RightShift = 117,
		RightMeta = 71,
		S = 62,
		Scroll = 115,
		Select = 27,
		Separator = 86,
		SpaceBar = 18,
		Subtract = 87,
		T = 63,
		Tab = 3,
		U = 64,
		UpArrow = 24,
		V = 65,
		VolumeDown = 130,
		VolumeMute = 129,
		VolumeUp = 131,
		W = 66,
		X = 67,
		Y = 68,
		Z = 69

	}

	/// <summary>
	/// Four OSX-specific keys/key-combinations.
	/// </summary>
	public enum KeybindingOSXOnly
	{

		FnDownArrow = 10004,
		FnLeftArrow = 10001,
		FnRightArrow = 10002,
		FnUpArrow = 10003

	}

}
