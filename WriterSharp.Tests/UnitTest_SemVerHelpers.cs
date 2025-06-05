using WriterSharp.Core;


namespace WriterSharp.Tests
{

	public class UnitTest_SemVerHelpers
	{

		[Fact]
		public void Test_1_0_0_OlderThan_1_5_0() => Assert.True(SemVerHelpers.IsVersionOlder(1, 0, 0, 1, 5, 0));

		[Fact]
		public void Test_1_5_1_NewerThan_1_5_0() => Assert.True(SemVerHelpers.IsVersionNewer(1, 5, 1, 1, 5, 0));

		[Fact]
		public void Test_1_5_2_EqualsTo_1_5_2() => Assert.True(SemVerHelpers.IsVersionNewerOrEqual(1, 5, 2, 1, 5, 2));

		[Fact]
		public void Test_1_5_1_NotEqualsToNotNewerThan_1_5_2() => Assert.False(SemVerHelpers.IsVersionNewerOrEqual(1, 5, 1, 1, 5, 2));

		[Theory]
		// v1.0.0 => v1.0.1
		[InlineData(1, 0, 0, 1, 0, 1, true)]
		// v1.0.2 => v1.0.1
		[InlineData(1, 0, 2, 1, 0, 1, false)]
		// v1.0.0 => v2.0.0
		[InlineData(1, 0, 0, 2, 0, 0, true)]
		// v3.0.0 => v2.5.9
		[InlineData(3, 0, 0, 2, 5, 9, false)]
		// v2.3.4 => v2.4.0
		[InlineData(2, 3, 4, 2, 4, 0, true)]
		// v2.4.1 => v2.4.0
		[InlineData(2, 4, 1, 2, 4, 0, false)]
		// v2.4.0 => v2.4.0
		[InlineData(2, 4, 0, 2, 4, 0, false)]
		public void Test_IsVersionOlderReturnsExpectedResult(int candidateMajor, int candidateMinor, int candidatePatch,
														int currentMajor, int currentMinor, int currentPatch,
														bool expectedResult)
		{

			var result = SemVerHelpers.IsVersionOlder(candidateMajor, candidateMinor, candidatePatch, currentMajor, currentMinor, currentPatch);
			Assert.Equal(result, expectedResult);

		}

		[Theory]
		// v1.0.0 => v1.0.1
		[InlineData(1, 0, 0, 1, 0, 1, true)]
		// v1.0.2 => v1.0.1
		[InlineData(1, 0, 2, 1, 0, 1, false)]
		// v1.0.0 => v2.0.0
		[InlineData(1, 0, 0, 2, 0, 0, true)]
		// v3.0.0 => v2.5.9
		[InlineData(3, 0, 0, 2, 5, 9, false)]
		// v2.3.4 => v2.4.0
		[InlineData(2, 3, 4, 2, 4, 0, true)]
		// v2.4.1 => v2.4.0
		[InlineData(2, 4, 1, 2, 4, 0, false)]
		// v2.4.0 => v2.4.0
		[InlineData(2, 4, 0, 2, 4, 0, true)]
		public void Test_IsVersionOlderOrEqualReturnsExpectedResult(int candidateMajor, int candidateMinor, int candidatePatch,
														int currentMajor, int currentMinor, int currentPatch,
														bool expectedResult)
		{

			var result = SemVerHelpers.IsVersionOlderOrEqual(candidateMajor, candidateMinor, candidatePatch, currentMajor, currentMinor, currentPatch);
			Assert.Equal(expectedResult, result);

		}

		[Theory]
		// v1.0.0 => v1.0.1
		[InlineData(1, 0, 0, 1, 0, 1, false)]
		// v1.0.2 => v1.0.1
		[InlineData(1, 0, 2, 1, 0, 1, true)]
		// v1.0.0 => v2.0.0
		[InlineData(1, 0, 0, 2, 0, 0, false)]
		// v3.0.0 => v2.5.9
		[InlineData(3, 0, 0, 2, 5, 9, true)]
		// v2.3.4 => v2.4.0
		[InlineData(2, 3, 4, 2, 4, 0, false)]
		// v2.4.1 => v2.4.0
		[InlineData(2, 4, 1, 2, 4, 0, true)]
		// v2.4.0 => v2.4.0
		[InlineData(2, 4, 0, 2, 4, 0, false)]
		public void Test_IsVersionNewerReturnsExpectedResult(int candidateMajor, int candidateMinor, int candidatePatch,
														int currentMajor, int currentMinor, int currentPatch,
														bool expectedResult)
		{

			var result = SemVerHelpers.IsVersionNewer(candidateMajor, candidateMinor, candidatePatch, currentMajor, currentMinor, currentPatch);
			Assert.Equal(result, expectedResult);

		}

		[Theory]
		// v1.0.0 => v1.0.1
		[InlineData(1, 0, 0, 1, 0, 1, false)]
		// v1.0.2 => v1.0.1
		[InlineData(1, 0, 2, 1, 0, 1, true)]
		// v1.0.0 => v2.0.0
		[InlineData(1, 0, 0, 2, 0, 0, false)]
		// v3.0.0 => v2.5.9
		[InlineData(3, 0, 0, 2, 5, 9, true)]
		// v2.3.4 => v2.4.0
		[InlineData(2, 3, 4, 2, 4, 0, false)]
		// v2.4.1 => v2.4.0
		[InlineData(2, 4, 1, 2, 4, 0, true)]
		// v2.4.0 => v2.4.0
		[InlineData(2, 4, 0, 2, 4, 0, true)]
		public void Test_IsVersionNewerOrEqualReturnsExpectedResult(int candidateMajor, int candidateMinor, int candidatePatch,
														int currentMajor, int currentMinor, int currentPatch,
														bool expectedResult)
		{

			var result = SemVerHelpers.IsVersionNewerOrEqual(candidateMajor, candidateMinor, candidatePatch, currentMajor, currentMinor, currentPatch);
			Assert.Equal(result, expectedResult);

		}

	}

}
