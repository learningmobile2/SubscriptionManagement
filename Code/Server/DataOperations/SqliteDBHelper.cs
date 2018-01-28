using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace DataOperations
{
    public static class SqliteDBHelper
    {
       internal static SQLiteCommand GetCommand(string databasePath)
        {
            SQLiteConnection sqlConnection;          // Database Connection Object
            SQLiteCommand sqlCommand;             // Database Command Object

            sqlConnection = new SQLiteConnection($"Data Source={databasePath};Version=3;New=True;");
            sqlConnection.Open();
            sqlCommand = sqlConnection.CreateCommand();           
            return sqlCommand;
        }

        internal static SQLiteConnection GetConnection(string databasePath)
        {
            SQLiteConnection sqlConnection;          // Database Connection Object
            sqlConnection = new SQLiteConnection($"Data Source={databasePath};Version=3;New=True;");
            sqlConnection.Open();
            return sqlConnection;
        }


        internal static void ExecuteNonQuery(SQLiteCommand command, string query)
        {
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        internal static DataSet GetResult(SQLiteCommand command, string query)
        {
            command.CommandText = query;
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        public static string GetString(this DataRow dataRow, string columnName, string defaultValue = "")
        {
            return dataRow[columnName] == DBNull.Value ? defaultValue : Convert.ToString(dataRow[columnName]);
        }

        public static int GetInt32(this DataRow dataRow, string columnName, int defaultValue = 0)
        {
            return dataRow[columnName] == DBNull.Value ? defaultValue : Convert.ToInt32(dataRow[columnName]);
        }
    }
}
