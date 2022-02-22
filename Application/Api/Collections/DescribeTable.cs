namespace Application.Collections
{
	public static class DescribeTable
	{
		public enum ColumnTypes
		{
			Id,
			LastChangeDateTime, LastChangeUser, LastChangeEmail, LastChangeAction,
			VarChar, VarChar50, VarChar100, VarChar150, VarChar200, VarCharMax,
			Char, Char50, Char100, Char150, Char200, CharMax,
			Boolean,
			TinyInt, SmallInt, MediumInt, Int, BigInt,
			Date, DateTime, Time, Timestamp, Year,
			Binary, VarBinary,
			TinyBlob, Blob, MediumBlob, LongBlob,
			TinyText, Text, MediumText, LongText,
			Enum,
			Json,
		}

		public enum ValueTypes
		{
			NotDefind,
			Null,
			NullString,
			NullInt,
			CurrentTimestamp
		}
	}
}
