namespace WriterSharp.Tests
{

	public class UnitTest_Testing
	{

		[Fact]
		public void ObjectEqualsToSelf() => Assert.Equal(1, 1.0);

		[Fact]
		public void ObjectNotEqualsToSelf() => Assert.NotEqual(1, 1.001);

	}

}
