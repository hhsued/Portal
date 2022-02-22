using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api
{
	public class QueryBuilder
	{
		private string _sqlQuery;
		public QueryBuilder Select()
		{
			_sqlQuery = "SELECT ";
			return this;
		}
		public QueryBuilder SelectAllColumns()
		{
			_sqlQuery += "* ";
			return this;
		}

		public QueryBuilder SelectColumn(string columnName)
		{
			_sqlQuery += columnName + " ";
			return this;
		}

		public QueryBuilder SelectColumn(string columnName, string columnAlias)
		{
			_sqlQuery += columnName + " as " + columnAlias + " ";
			return this;
		}

		public QueryBuilder SelectColumns(params string[] columnNames)
		{
			foreach (var columnName in columnNames)
			{
				_sqlQuery += columnName + ", ";
			}
			_sqlQuery = _sqlQuery[..^2];
			return this;
		}

		public QueryBuilder SelectColumns(params Models.QueryBuilder.SelectColumn[] columns)
		{
			foreach (var column in columns)
			{
				_sqlQuery += column.Get() + ", ";
			}
			_sqlQuery = _sqlQuery[..^2];
			return this;
		}


		public QueryBuilder Where(string searchColumn, dynamic searchValue)
		{
			
			if (!_sqlQuery.Contains("WHERE")) _sqlQuery += "WHERE ";
			var needsQuotationMarks = (new List<string>() {"System.String"}.Contains(searchValue.GetType().ToString())) ? true : false;

			_sqlQuery += searchColumn + " = " + (needsQuotationMarks ? "'" : "") + searchValue.ToString() +
			             (needsQuotationMarks ? "' " : " ");

			return this;
		}
		public QueryBuilder Where(string searchColumn, dynamic searchValue, Collections.QueryBuilder.CompareOperators compareOperator)
		{
			if (!_sqlQuery.Contains("WHERE")) _sqlQuery += "WHERE ";
			var needsQuotationMarks = (new List<string>() { "System.String" }.Contains(searchValue.GetType().ToString())) ? true : false;

			_sqlQuery += searchColumn + " " + GetCompareOperator(compareOperator) + " " + (needsQuotationMarks ? "'" : "") + searchValue.ToString() +
			             (needsQuotationMarks ? "' " : " ");

			return this;
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

		public QueryBuilder WhereAnd()
		{
			_sqlQuery += "AND ";
			return this;
		}

		public QueryBuilder WhereOr()
		{
			_sqlQuery += "OR ";
			return this;
		}
		public QueryBuilder OrderBy(dynamic OrderBy)
		{
			//$this->OrderBy = $OrderBy;
			return this;
		}

		public QueryBuilder Limit(dynamic Limit)
		{
			//$this->Limit = $Limit;
			return this;
		}

		private void WhereClause(dynamic Data)
		{
			var lstrQuery = " WHERE ";
			foreach (Data as key => value)
			{
				if (is_array(value))
				{
					lstrQuery += key. " ";
					switch (value[1])
					{
						case "ge":
							lstrQuery += " >= "" . value[0] . "" AND ";
							break;
					}
				}
				else
				{
					lstrQuery += key. " = "" . value . "" AND ";
				}
			}
			return strings::shorten(lstrQuery, 5);
		}

		private void UpdateDataClause(dynamic Data)
		{
			var lstrValues = " SET ";
			foreach (Data as Column => Value)
			{
				lstrValues += Column. " = "" . Value . "", ";
			}
			return strings::shorten(lstrValues, 2);
		}

		private void insertStatement(dynamic Table, dynamic Data)
		{
			var lstrSQL = "INSERT INTO `".Table. "` ";
			var lstrColumns = "";
			var lstrValues = "";
			foreach (Data as lstrColumn => lstrValue)
			{
				lstrColumns += lstrColumn. ", ";
				lstrValues += """ . lstrValue . "", ";

			}
			lstrSQL += "(" + (new strings)->shorten(lstrColumns, "2") + ") VALUES (" + (new strings)->shorten(lstrValues, 2) + ")";

			return (new strings)->convertUTF8(lstrSQL);
		}
		public void Insert(dynamic Table, dynamic Data)
		{
			return this.Execute(this.InsertStatement(Table, Data), "id");
		}

		private void BuildWhere(dynamic Where)
		{
			var lstrQuery = "";
			if (Where != null)
			{
				if (is_array(Where))
				{
					lstrQuery += " WHERE ";
					foreach (Where as larrWhere)
					{
						switch (count(larrWhere))
						{
							case 1:
								lstrQuery += this.CheckTypeForWhere(larrWhere). " AND ";
								break;
							case 2:
								lstrQuery += larrWhere[0]. " = ". this.CheckTypeForWhere(larrWhere[1]). " AND ";
								break;
							case 3:
								lstrQuery += larrWhere[0]. " ".larrWhere[1]. " ". this.CheckTypeForWhere(larrWhere[2]). " AND ";
								break;
						}
					}
					lstrQuery = strings::shorten(lstrQuery, 5);
				}
				else
				{
					lstrQuery += " WHERE " + Where;
				}
			}
			return lstrQuery;
		}

		private void BuildOrderBy(dynamic OrderBy)
		{
			var lstrQuery = "";
			if (OrderBy != null)
			{
				if (is_array(OrderBy))
				{
					foreach (OrderBy as lstrOrderBy)
					{
						lstrQuery += lstrOrderBy. ", ";
					}
					lstrQuery = strings::shorten(lstrQuery, 2);
				}
				else
				{
					lstrQuery += " ".OrderBy;
				}
				return lstrQuery;
			}
			return lstrQuery;
		}

		private void BuildColumns(dynamic Columns)
		{
			var lstrQuery = "";
			if (Columns != null)
			{
				if (is_array(Columns))
				{
					lstrQuery += " ";
					if (gettype(array_keys(Columns)[0]) == "integer")
					{
						foreach (Columns as lstrColumn)
						{
							lstrQuery += lstrColumn. ", ";
						}
					}
					else
					{
						foreach (Columns as lstrColumn => lstrAlias)
						{
							lstrQuery += lstrColumn. " as ".lstrAlias. ", ";
						}
					}
					lstrQuery = strings::shorten(lstrQuery, 2);
				}
				else
				{
					lstrQuery += " ".Columns;
				}
			}
			else
			{
				lstrQuery += " *";
			}
			return lstrQuery;
		}

		private void BuildTable(dynamic Table)
		{
			var lstrQuery = "";
			if (Table != null)
			{
				lstrQuery += " FROM";
				if (is_array(Table))
				{
					lstrQuery += " ";
					foreach (Table as lmixTable)
					{
						if (is_array(lmixTable))
						{
							lstrQuery += lmixTable[0]. " AS ".lmixTable[1];
						}
						else
						{
							lstrQuery += lmixTable. ", ";
						}
					}
					lstrQuery = strings::shorten(lstrQuery, 2);
				}
				else
				{
					lstrQuery += " ".Table;
				}
			}
			else
			{
				lstrQuery += " *";
			}
			return lstrQuery;
		}

		private void BuildSelectQuery(dynamic Table, dynamic Columns, dynamic Where, dynamic OrderBy, dynamic Limit)
		{
			var lstrQuery = "SELECT";
			lstrQuery += this.BuildColumns(Columns);
			lstrQuery += this.BuildTable(Table);
			lstrQuery += this.BuildWhere(Where);
			lstrQuery += this.BuildOrderBy(OrderBy);
			if (Limit != null)
			{
				lstrQuery += " LIMIT ".Limit;
			}
			return lstrQuery;
		}

		private void BuildQuery(dynamic QueryType, dynamic Table, dynamic Columns, dynamic Where, dynamic OrderBy, dynamic Limit)
		{
			var lstrQuery = "";
			switch (strtolower(QueryType))
			{
				case "get":
				case "select":
				case "fetch":
					lstrQuery = this.BuildSelectQuery(Table, Columns, Where, OrderBy, Limit);
			}
			return lstrQuery;
		}
	}
}
