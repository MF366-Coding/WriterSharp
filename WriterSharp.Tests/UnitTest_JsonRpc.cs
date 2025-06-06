using System;

using WriterSharp.Core.JsonRpc;
using WriterSharp.Plugins;


namespace WriterSharp.Tests
{

	public class UnitTest_JsonRpc
	{

		[Fact]
		public void Test_JsonRpcVersion2()
		{

			ReturnData retData = new(6, true, 200, "Testing, testing.");
			Assert.Equal(2.0, JsonRpc.FromReturnData(retData)["jsonrpc"]!.GetValue<double>());

		}

		[Fact]
		public void Test_JsonRpcIdIs70()
		{

			ReturnData retData = new(70, false, 565, "Something happened.", null, "An error occured.");
			Assert.Equal(retData.Id, JsonRpc.FromReturnData(retData)["id"]!.GetValue<int>());

		}

		[Theory]
		[InlineData(1, true, 0, "Success!", null, null)]
		[InlineData(543, false, 5345, "Error!", "Values", "Info")]
		[InlineData(35, false, 45, "Response goes here", null, "Don't send this back!!")]
		[InlineData(69, true, 12, "some_random_return_value", null, null)]
		[InlineData(-2, false, 2, "Not Success!", "This is a special value", null)]
		[InlineData(-56, true, 1, "KoRn is love, KoRn is life", "Special value, very special indeed", "Special info")]
		[InlineData(-56, true, 1, null, "Good value", "Bad info")]
		[InlineData(0, true, 200, "OK", null, null)]
		[InlineData(404, false, 404, "Not Found", "URL Missing", "Check endpoint spelling")]
		[InlineData(500, false, 500, "Internal Error", null, "NullReferenceException occurred")]
		[InlineData(123, true, 100, "Processed", "Intermediate step", null)]
		[InlineData(-999, false, 999, "Critical Failure", "Core dump initiated", "Memory leak suspected")]
		[InlineData(42, true, 1337, "Life, Universe, Everything", null, null)]
		[InlineData(777, true, 777, "Jackpot!", "All systems go", "Test run clean")]
		[InlineData(-1, false, 1, "Failure", "Debug info", "Unhandled exception")]
		[InlineData(88, true, 8, "Echo", "Repeat this", "Loop detected")]
		[InlineData(314, true, 159, "Pi Response", "Math stuff", "Irrational response accepted")]
		[InlineData(666, false, 666, "Devil's in the details", "Unholy value", "Run exorcism.exe")]
		[InlineData(202, true, 202, "Accepted", "Still processing", "Might take a while")]
		[InlineData(1, false, 0, "", "", "")]
		[InlineData(-100, false, 0, null, null, null)]
		public void Test_ReturnDataToJsonKeepsData(int id, bool success, ushort code, string? msg, string? value, string? info)
		{

			NullReferenceException innerException = new("Error message goes here");
			ReturnData retData = new(id, success, code, msg, value, info, innerException);
			var jsonrpc = JsonRpc.FromReturnData(retData);

			Assert.Equal(2.0, jsonrpc["jsonrpc"]!.GetValue<double>());
			Assert.Equal(retData.Id, jsonrpc["id"]!.GetValue<int>());
			Assert.Equal(retData.Message, jsonrpc["result"]?["message"]?.GetValue<string>());
			Assert.Equal(retData.Code, jsonrpc["result"]?["code"]!.GetValue<ushort>());
			Assert.Equal(retData.AdditionalInformation, jsonrpc["result"]?["additionalInformation"]?.GetValue<string>());
			Assert.Equal(retData.IsSuccessful, jsonrpc["result"]?["isSuccessful"]!.GetValue<bool>());
			Assert.Equal(retData.VerboseValue, jsonrpc["result"]?["verboseValue"]?.GetValue<string>());
			Assert.Equal(retData.InnerException?.GetType().FullName, jsonrpc["result"]?["innerException"]?["type"]?.GetValue<string>());
			Assert.Equal(retData.InnerException?.Message, jsonrpc["result"]?["innerException"]?["message"]?.GetValue<string>());

		}

		[Fact]
		public void Test_ValueConversionWorking()
		{

			ReturnData<string> retData1 = new(3, true, 643, "Generic Success Message", "24", null, null);
			ReturnData<NotImplementedException> retData2 = new(54, false, 132, "Generic Error Message", new("Null not allowed"), "Test", null);
			var jsonrpc1 = JsonRpc.FromReturnData<string>(retData1);
			var jsonrpc2 = JsonRpc.FromReturnData<NotImplementedException>(retData2);

			Assert.Equal(retData1.VerboseValue, jsonrpc1["result"]!["verboseValue"]!.GetValue<string>());
			Assert.Equal(retData2.VerboseValue!.Message, jsonrpc2["result"]!["verboseValue"]!.GetValue<string>());

		}

	}

}
