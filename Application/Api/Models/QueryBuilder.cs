using System.Collections.Generic;
using System.Linq;
using Org.BouncyCastle.Asn1.CryptoPro;

namespace Application.Api.Models
{
	public class QueryBuilder
	{
		public class NamedTable
		{
			private string _tableName;
			public NamedTable(string tableName, params string[] columns){

			}
		}
		public class Table : NamedTable
		{
			private string[] _columns;

			public Table(params string[] columns)
			{
				_columns = columns;
			}

			}

		public class SelectColumn
		{
			private readonly string columnName;
			private readonly string columnAlias;

			public SelectColumn(string columnName, string columnAlias)
			{
				this.columnName = columnName;
				this.columnAlias = columnAlias;
			}

			public string Get()
			{
				return columnName + " as " + columnAlias;

			}

		}

		public class Where
		{
			private readonly string _searchColumn;
			private readonly dynamic _searchValue;
			private readonly Collections.QueryBuilder.CompareOperators _compareOperator;

			public Where(string searchColumn, dynamic searchValue, Collections.QueryBuilder.CompareOperators compareOperator)
			{
				_searchColumn = searchColumn;
				_searchValue = searchValue;
				_compareOperator = compareOperator;
			}

			public string Get()
			{
				var needsQuotationMarks = (new List<string>() { "System.String" }.Contains(_searchValue.GetType().ToString()))
					? true
					: false;

				return _searchColumn + " " + GetCompareOperator(_compareOperator) + " " + (needsQuotationMarks ? "'" : "") +
							 _searchValue.ToString() +
							 (needsQuotationMarks ? "' " : " ");
			}

			private static string GetCompareOperator(Collections.QueryBuilder.CompareOperators compareOperator)
			{
				return compareOperator switch
				{
					Collections.QueryBuilder.CompareOperators.equal => "=",
					Collections.QueryBuilder.CompareOperators.notEqual => "!=",
					Collections.QueryBuilder.CompareOperators.greaterThan => ">",
					Collections.QueryBuilder.CompareOperators.lessThan => "<",
					Collections.QueryBuilder.CompareOperators.lessThanOrEqual => "<=",
					Collections.QueryBuilder.CompareOperators.greaterThanOrEqual => ">=",
					_ => "="
				};

			}
		}
	}
}
