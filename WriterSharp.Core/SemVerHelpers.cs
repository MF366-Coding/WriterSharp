namespace WriterSharp.Core
{

	/// <summary>
	/// Helpers for semantic version calculations.
	/// </summary>
	public static class SemVerHelpers
	{

		/// <summary>
		/// Checks if a given version is older than another one.
		/// Split the version (major, minor, patch) across arguments.
		/// </summary>
		/// <param name="candidateMajor">Major value of the candidate version (X in X.Y.Z).</param>
		/// <param name="candidateMinor">Minor value of the candidate version (Y in X.Y.Z).</param>
		/// <param name="candidatePatch">Patch value of the candidate version (Z in X.Y.Z).</param>
		/// <param name="currentMajor">Major value of the current version (X in X.Y.Z).</param>
		/// <param name="currentMinor">Minor value of the current version (Y in X.Y.Z).</param>
		/// <param name="currentPatch">Patch value of the current version (Z in X.Y.Z).</param>
		/// <returns>A boolean confirming whether the candidate is older than the current version</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Pending>")] // simply because it looks cleaner with explicit ifs
		public static bool IsVersionOlder(int candidateMajor, int candidateMinor, int candidatePatch, int currentMajor, int currentMinor, int currentPatch)
		{

			if (candidateMajor > currentMajor) return false;
			if (candidateMajor < currentMajor) return true;

			if (candidateMinor > currentMinor) return false;
			if (candidateMinor < currentMinor) return true;

			return candidatePatch < currentPatch;

		}

		/// <summary>
		/// Checks if a given version is newer than another one.
		/// Split the version (major, minor, patch) across arguments.
		/// </summary>
		/// <param name="candidateMajor">Major value of the candidate version (X in X.Y.Z).</param>
		/// <param name="candidateMinor">Minor value of the candidate version (Y in X.Y.Z).</param>
		/// <param name="candidatePatch">Patch value of the candidate version (Z in X.Y.Z).</param>
		/// <param name="currentMajor">Major value of the current version (X in X.Y.Z).</param>
		/// <param name="currentMinor">Minor value of the current version (Y in X.Y.Z).</param>
		/// <param name="currentPatch">Patch value of the current version (Z in X.Y.Z).</param>
		/// <returns>A boolean confirming whether the candidate is newer than the current version</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Pending>")] // simply because it looks cleaner with explicit ifs
		public static bool IsVersionNewer(int candidateMajor, int candidateMinor, int candidatePatch, int currentMajor, int currentMinor, int currentPatch)
		{

			if (candidateMajor < currentMajor) return false;
			if (candidateMajor > currentMajor) return true;

			if (candidateMinor < currentMinor) return false;
			if (candidateMinor > currentMinor) return true;

			return candidatePatch > currentPatch;

		}

		/// <summary>
		/// Checks if a given version is older than (or the same as) another one.
		/// Split the version (major, minor, patch) across arguments.
		/// </summary>
		/// <param name="candidateMajor">Major value of the candidate version (X in X.Y.Z).</param>
		/// <param name="candidateMinor">Minor value of the candidate version (Y in X.Y.Z).</param>
		/// <param name="candidatePatch">Patch value of the candidate version (Z in X.Y.Z).</param>
		/// <param name="currentMajor">Major value of the current version (X in X.Y.Z).</param>
		/// <param name="currentMinor">Minor value of the current version (Y in X.Y.Z).</param>
		/// <param name="currentPatch">Patch value of the current version (Z in X.Y.Z).</param>
		/// <returns>A boolean confirming whether the candidate is older than or equals to the current version</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Pending>")] // simply because it looks cleaner with explicit ifs
		public static bool IsVersionOlderOrEqual(int candidateMajor, int candidateMinor, int candidatePatch, int currentMajor, int currentMinor, int currentPatch)
		{

			if ((candidateMajor == currentMajor)
				&& (candidateMinor == currentMinor)
				&& (candidatePatch == currentPatch)) return true;

			if (candidateMajor > currentMajor) return false;
			if (candidateMajor < currentMajor) return true;

			if (candidateMinor > currentMinor) return false;
			if (candidateMinor < currentMinor) return true;

			return candidatePatch < currentPatch;

		}

		/// <summary>
		/// Checks if a given version is newer than (or the same as) another one.
		/// Split the version (major, minor, patch) across arguments.
		/// </summary>
		/// <param name="candidateMajor">Major value of the candidate version (X in X.Y.Z).</param>
		/// <param name="candidateMinor">Minor value of the candidate version (Y in X.Y.Z).</param>
		/// <param name="candidatePatch">Patch value of the candidate version (Z in X.Y.Z).</param>
		/// <param name="currentMajor">Major value of the current version (X in X.Y.Z).</param>
		/// <param name="currentMinor">Minor value of the current version (Y in X.Y.Z).</param>
		/// <param name="currentPatch">Patch value of the current version (Z in X.Y.Z).</param>
		/// <returns>A boolean confirming whether the candidate is newer than  or equals to the current version</returns>
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
