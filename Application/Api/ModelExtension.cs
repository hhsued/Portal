using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Application.Api
{
	public class ModelExtension
	{
		public ModelExtension WriteToTable()
		{
			const string connectionString = @"server=hh-sued.de;userid=d038ec20;password=Nak123!Db;database=d038ec20";
			return this;
		}

		public ModelExtension UpdateTable()
		{
			return this;
		}

		public ModelExtension CheckModel()
		{//Prüfcodes usw.
			return this;
		}
		public ModelExtension First()
		{
			var queryFactory = InitMapping();

			MapRow(
				queryFactory
					.Query(
						MyName())
					.First());

			return this;
		}

		public void GetById(int id)
		{
			var queryFactory = InitMapping();
			MapRow(
				queryFactory
					.Query(
						MyName())
					.Where("Id", id)
					.First());
		}

		public void GetByKey(string key, string value)
		{
			var queryFactory = InitMapping();
			MapRow(
				queryFactory
					.Query(
						MyName())
					.Where(key, value)
					.First());
		}

		private string MyName()
		{
			return this.GetType().Name;
		}

		private static QueryFactory InitMapping()
		{
			const string connectionString = @"server=hh-sued.de;userid=d038ec20;password=Nak123!Db;database=d038ec20";

			return 
				new QueryFactory(
					new MySqlConnection(connectionString), 
					new MySqlCompiler());
		}
		private void MapRow(dynamic row)
		{
			foreach (var keyValuePair in row)
			{
				if (
					this
						.GetType()
						.GetProperty(keyValuePair.Key) 
					== 
					null) continue;
				if (
					keyValuePair
						.Value
						.GetType()
						.FullName 
					== 
					this
						.GetType()
						.GetProperty(keyValuePair.Key)
						.PropertyType
						.FullName)
				{
					this
						.GetType()
						.GetProperty(keyValuePair.Key)
						.SetValue(this, keyValuePair.Value);
				}
				else
				{
					this
						.GetType()
						.GetProperty(keyValuePair.Key)
						.SetValue(
							Datatypes
								.ConvertToMyType(keyValuePair.Value));
				}
			}
		}
	}
}
