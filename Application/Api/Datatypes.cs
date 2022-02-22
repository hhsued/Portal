using System;

namespace Application
{
	public static class Datatypes
	{
		public static dynamic? ConvertToMyType(dynamic inputValue)
		{
			return inputValue switch
			{
				"System.Int32" => Convert.ToInt32(inputValue),
				"System.Boolean" => Convert.ToBoolean(inputValue),
				"System.Char" => Convert.ToChar(inputValue),
				"System.String" => Convert.ToString(inputValue),
				"System.Double" => Convert.ToDouble(inputValue),
				"System.DateTime" => Convert.ToDateTime(inputValue),
				"System.Byte" => Convert.ToByte(inputValue),
				"System.Decimal" => Convert.ToDecimal(inputValue),
				"System.Int16" => Convert.ToInt16(inputValue),
				"System.Int64" => Convert.ToInt64(inputValue),
				"System.SByte" => Convert.ToSByte(inputValue),
				"System.Single" => Convert.ToSingle(inputValue),
				"System.UInt16" => Convert.ToUInt16(inputValue),
				"System.UInt32" => Convert.ToUInt32(inputValue),
				"System.UInt64" => Convert.ToUInt64(inputValue),
				_ => null
			};
		}
	}
}
