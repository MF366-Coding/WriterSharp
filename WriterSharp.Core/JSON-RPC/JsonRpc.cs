using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;

using WriterSharp.Core.ErrorManagement;
using WriterSharp.Plugins;


namespace WriterSharp.Core.JsonRpc
{

	/// <summary>
	/// Helper functions for JSON-RPC handling.
	/// </summary>
	public static class JsonRpc
	{

		/// <summary>
		/// Converts <see cref="ICachableError" /> to JSON-RPC.
		/// </summary>
		/// <param name="cachableError">The cachable error to convert</param>
		/// <returns>A readonly version of the error, ready for use as JSON-RPC.</returns>
		public static ReadOnlyDictionary<string, JsonNode?> FromCachableError(ICachableError cachableError)
		{

			JsonObject rootNode = new();

			// first let's create ze basic structure
			rootNode.Add("jsonrpc", 2.0);
			rootNode.Add("id", -1); // cachable errors have no ID

			// now for ze result
			JsonObject result = new();
			result.Add("message", cachableError.Message);
			result.Add("code", cachableError.ErrorCode);

			// exceptionsss
			if (cachableError.Exception is not null)
			{

				JsonObject exception = new();
				exception.Add("type", cachableError.Exception.GetType().FullName);
				exception.Add("message", cachableError.Exception.Message);
				exception.Add("stackTrace", cachableError.Exception.StackTrace);

				result.Add("exception", exception);

			}
			else
			{

				result.Add("exception", null);

			}

			rootNode.Add("result", result);
			return rootNode.AsReadOnly();

		}

		/// <summary>
		/// Converts <see cref="ReturnData" /> to JSON-RPC.
		/// </summary>
		/// <param name="returnData">The return data to convert</param>
		/// <returns>A readonly version of the return data, ready for use as JSON-RPC.</returns>
		public static ReadOnlyDictionary<string, JsonNode?> FromReturnData(ReturnData returnData)
		{

			JsonObject rootNode = new();

			// first let's create ze basic structure
			rootNode.Add("jsonrpc", 2.0);
			rootNode.Add("id", returnData.Id);

			// now for ze result
			JsonObject result = new();
			result.Add("isSuccessful", returnData.IsSuccessful);
			result.Add("code", returnData.Code);
			result.Add("message", returnData.Message);
			result.Add("verboseValue", returnData.VerboseValue);
			result.Add("additionalInformation", returnData.AdditionalInformation);

			// exceptionsss
			if (returnData.InnerException is not null)
			{

				JsonObject exception = new();
				exception.Add("type", returnData.InnerException.GetType().FullName);
				exception.Add("message", returnData.InnerException.Message);
				exception.Add("stackTrace", returnData.InnerException.StackTrace);

				result.Add("innerException", exception);

			}
			else
			{

				result.Add("innerException", null);

			}

			rootNode.Add("result", result);
			return rootNode.AsReadOnly();

		}

		/// <summary>
		/// Converts a JSON-RPC dictionary to a <see cref="ReturnData" /> record.
		/// </summary>
		/// <param name="jsonRpc">The dictionary to convert</param>
		/// <returns>The return data.</returns>
		public static ReturnData ToReturnData(ReadOnlyDictionary<string, JsonNode?> jsonRpc)
		{

			int? id = jsonRpc["id"]?.GetValue<int>();
			bool? success = jsonRpc["result"]?["isSuccessful"]?.GetValue<bool>();
			ushort? code = jsonRpc["result"]?["code"]?.GetValue<ushort>();
			string? msg = jsonRpc["result"]?["message"]?.GetValue<string?>();
			string? value = jsonRpc["result"]?["verboseValue"]?.GetValue<string?>();
			string? info = jsonRpc["result"]?["additionalInformation"]?.GetValue<string?>();
			Exception? exception = null;

			if (jsonRpc["result"]?["innerException"] is not null)
			{

				exception = new(jsonRpc["result"]?["innerException"]?["message"]?.GetValue<string?>());

			}

			return new(id ?? 0, success ?? false, code ?? 1, msg, value, info, exception);

		}

		/// <summary>
		/// Converts <see cref="ReturnData{T}" /> to JSON-RPC, where <strong>TValue</strong>
		/// is <typeparamref name="T"/>.
		/// </summary>
		/// <param name="returnData">The return data to convert</param>
		/// <returns>A readonly version of the return data, ready for use as JSON-RPC.</returns>
		public static ReadOnlyDictionary<string, JsonNode?> FromReturnData<T>(ReturnData<T> returnData)
			where T : class
		{

			JsonObject rootNode = new();

			// first let's create ze basic structure
			rootNode.Add("jsonrpc", 2.0);
			rootNode.Add("id", returnData.Id);

			// now for ze result
			JsonObject result = new();
			result.Add("isSuccessful", returnData.IsSuccessful);
			result.Add("code", returnData.Code);
			result.Add("message", returnData.Message);
			result.Add("additionalInformation", returnData.AdditionalInformation);

			// value
			if (returnData.VerboseValue is not null)
			{

				if (returnData.VerboseValue is string stringifiedValue)
				{

					result.Add("verboseValue", stringifiedValue);

				}
				else if (returnData.VerboseValue is Exception exValue)
				{

					result.Add("verboseValue", exValue.Message);

				}
				else
				{

					result.Add("verboseValue", returnData.VerboseValue.ToString());

				}

			}
			else
			{

				result.Add("verboseValue", null);

			}

			// exceptionsss
			if (returnData.InnerException is not null)
			{

				JsonObject exception = new();
				exception.Add("type", returnData.InnerException.GetType().FullName);
				exception.Add("message", returnData.InnerException.Message);
				exception.Add("stackTrace", returnData.InnerException.StackTrace);

				result.Add("innerException", exception);

			}
			else
			{

				result.Add("innerException", null);

			}

			rootNode.Add("result", result);
			return rootNode.AsReadOnly();

		}

	}

}
