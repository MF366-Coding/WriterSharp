namespace WriterSharp.Core
{

	public static class SemVerHelpers
	{

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Pending>")] // simply because it looks cleaner with explicit ifs
		public static bool IsVersionOlder(int candidateMajor, int candidateMinor, int candidatePatch, int currentMajor, int currentMinor, int currentPatch)
		{

			if (candidateMajor > currentMajor) return false;
			if (candidateMajor < currentMajor) return true;

			if (candidateMinor > currentMinor) return false;
			if (candidateMinor < currentMinor) return true;

			return candidatePatch < currentPatch;

		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Pending>")] // simply because it looks cleaner with explicit ifs
		public static bool IsVersionNewer(int candidateMajor, int candidateMinor, int candidatePatch, int currentMajor, int currentMinor, int currentPatch)
		{

			if (candidateMajor < currentMajor) return false;
			if (candidateMajor > currentMajor) return true;

			if (candidateMinor < currentMinor) return false;
			if (candidateMinor > currentMinor) return true;

			return candidatePatch > currentPatch;

		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Pending>")] // simply because it looks cleaner with explicit ifs
		public static bool IsVersionOlderOrEqual(int candidateMajor, int candidateMinor, int candidatePatch, int currentMajor, int currentMinor, int currentPatch)
		{

			if ((candidateMajor == currentMajor)
				&& (candidateMinor == currentMinor)
				&& (candidatePatch == currentPatch)) return true;

			if (candidateMajor < currentMajor) return false;
			if (candidateMajor > currentMajor) return true;

			if (candidateMinor < currentMinor) return false;
			if (candidateMinor > currentMinor) return true;

			return candidatePatch > currentPatch;

		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Pending>")] // simply because it looks cleaner with explicit ifs
		public static bool IsVersionNewerOrEqual(int candidateMajor, int candidateMinor, int candidatePatch, int currentMajor, int currentMinor, int currentPatch)
		{

			if ((candidateMajor == currentMajor)
				&& (candidateMinor == currentMinor)
				&& (candidatePatch == currentPatch)) return true;

			if (candidateMajor < currentMajor) return false;
			if (candidateMajor > currentMajor) return true;

			if (candidateMinor < currentMinor) return false;
			if (candidateMinor > currentMinor) return true;

			return candidatePatch > currentPatch;

		}

	}

}
