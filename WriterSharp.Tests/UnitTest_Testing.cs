namespace WriterSharp.Tests
{

	public class UnitTest_Testing
	{

		[Fact]
		public void Test_ShouldBeTrue() => Assert.True(1 == 1);

		[Fact]
		public void Test_ShouldBeFalse() => Assert.False(1 == 2);

	}

}
