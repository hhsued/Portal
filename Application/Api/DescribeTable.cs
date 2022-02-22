using System;

namespace Application
{
	public class DescribeTable
	{
		[AttributeUsage(
			AttributeTargets.Class,
			AllowMultiple = false)]
		public class TableDescription : Attribute
		{
			public string Name { get; set; }
			public string Collate { get; set; } = "utf8mb4_general_ci";

			public TableDescription(string name)
			{
				Name = name;
			}

			public TableDescription(string name, string collate) : this(name)
			{
				Collate = collate;
			}
		}
		[AttributeUsage(
			AttributeTargets.Property,
			AllowMultiple = true)]
		public class ColumnDescription : Attribute
		{
			public string ColumnName { get; set; }
			public bool IsPrimary { get; set; } = false;
			public bool AutoIncrement { get; set; } = false;
			public Application.Collections.DescribeTable.ColumnTypes ColumnType { get; set; }
			public int Length { get; set; } = 0;
			public bool IsNullable { get; set; } = true;
			public string DefaultValue { get; set; } = string.Empty;
			public Application.Collections.DescribeTable.ValueTypes ValueType { get; set; } = Application.Collections.DescribeTable.ValueTypes.NotDefind;
			public string OnUpdateValue { get; set; } = string.Empty;
			public Application.Collections.DescribeTable.ValueTypes OnUpdateValueType { get; set; } = Application.Collections.DescribeTable.ValueTypes.NotDefind;
			public string Collate { get; set; } = "utf8mb4_general_ci";

			public ColumnDescription()
			{
				ColumnName = "Id";
				IsPrimary = true;
				AutoIncrement = true;
				ColumnType = Application.Collections.DescribeTable.ColumnTypes.Int;
				IsNullable = false;
			}

			public ColumnDescription(
				string columnName,
				Application.Collections.DescribeTable.ColumnTypes columnType)
			{
				ColumnName = columnName;
				ColumnType = columnType;
			}

			public ColumnDescription(
				string columnName, 
				bool isPrimary, 
				bool autoIncrement, 
				Application.Collections.DescribeTable.ColumnTypes columnType, 
				int length, 
				bool isNullable, 
				string defaultValue, 
				Application.Collections.DescribeTable.ValueTypes valueType, 
				string onUpdateValue,
				Application.Collections.DescribeTable.ValueTypes onUpdateValueType, 
				string collate)
			{
				ColumnName = columnName;
				IsPrimary = isPrimary;
				AutoIncrement = autoIncrement;
				ColumnType = columnType;
				Length = length;
				IsNullable = isNullable;
				DefaultValue = defaultValue;
				ValueType = valueType;
				OnUpdateValue = onUpdateValue;
				OnUpdateValueType = onUpdateValueType;
				Collate = collate;
			}

		}

	}
}
