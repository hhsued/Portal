using System;
using System.Data.SQLite;
using System.IO;

namespace Application.Api
{
  public static class Database
  {
    private static SQLiteConnection _connectionObject;
    private static string _sqlQuery;

    private static string BuildConnectionString()
    {
	    return $"Data Source={Path.Combine(Environment.CurrentDirectory,"Data","Db","Application.db")};Version=3;New=True;Compress=True;";
    }

    private static void PreCheck()
    {
	    var connectionString = BuildConnectionString();
	    _connectionObject = new SQLiteConnection(connectionString);
      _connectionObject.Open();
    }

    public static int ExecuteGetCount(string query)
    {
	    var sqliteCommand = Prepare(query);
	    var reader = sqliteCommand.ExecuteReader();
	    return reader.RecordsAffected;
    }

    public static long ExecuteGetInsertedId(string query)
    {
	    var sqliteCommand = Prepare(query);
	    sqliteCommand.ExecuteNonQuery();
	    return _connectionObject.LastInsertRowId;
    }

    public static bool ExecuteGetSuccess(string query)
    {
	    var sqliteCommand = Prepare(query);
	    sqliteCommand.ExecuteNonQuery();

	    return (_connectionObject.Changes > 0) ? true : false;
    }

    public static SQLiteDataReader ExecuteGetResult(string query)
    {
	    var sqliteCommand = Prepare(query);
	    return sqliteCommand.ExecuteReader();
    }

    public static void Execute(string query)
    {
	    var sqliteCommand = Prepare(query);
	    sqliteCommand.ExecuteNonQuery();
    }
    public static SQLiteCommand Prepare(string query = null)
    {
	    query ??= _sqlQuery;
      PreCheck();
      
      var sqLiteCommand = _connectionObject.CreateCommand();
      sqLiteCommand.CommandText = query;
      return sqLiteCommand;
    }

    // ++++++++++++++++++++++++++++++ FIELDS
    public static void Create(dynamic Table, dynamic Data, dynamic Status)
    {
	    //Insert
    }
    public static void Read()
    { // select
    }

    public static void Update()
    {
	    //Update
    }

    public static void Delete()
    {
	    //Delete
    }
    public static void Version(dynamic ID, dynamic Table, dynamic version)
    {
    }
    public static void Status(dynamic ID, dynamic Table, dynamic Type, dynamic Status)
    {
    }
    
    public static void Truncate(string table)
    {
      Execute($"TRUNCATE TABLE {table}");
    }

    public static void First(string query)
    {
	    var reader = ExecuteGetResult(query);
      if (reader == null) return;
      while (reader.Read()) {
      }
    }
    public static void All(string query)
    {

    }


    public static int Count(string query)
    {
	    return ExecuteGetCount(query);
    }
    public static SQLiteDataReader Get(string query)
    {
	    return ExecuteGetResult(query);
    }

    public static void NewVersion(dynamic Table, dynamic Status, dynamic SearchData, dynamic UpdateData = null)
    {
    }
  }
}