using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Entities;
using SMS.Entities.DataInterface;

namespace DataOperations
{
    public class DatabaseOperations : IDataStore
    {
        public DBType DBType { get; set; }
        string databasePath;

        public DatabaseOperations(string databasePath, DBType dBType)
        {
            this.databasePath = string.IsNullOrWhiteSpace(databasePath) ? throw new ArgumentNullException(nameof(databasePath)) : databasePath;
            this.DBType = dBType;
        }

        private int GetNextId(SQLiteCommand sqliteDBCommand, string tableName, string keyColumn = "Id")
        {
            string query = $"SELECT MAX({keyColumn}) FROM {tableName}";
            var result = SqliteDBHelper.GetResult(sqliteDBCommand, query);
            int lastId = 0;
            if (result.Tables[0].Rows.Count != 0)
            {
                var value = result.Tables[0].Rows[0][0];
                lastId = value == DBNull.Value ? 0 : Convert.ToInt32(value);
            }

            return ++lastId;
        }

        public Customer CreateCustomer(Customer customer)
        {
            using (SQLiteConnection dataConnection = SqliteDBHelper.GetConnection(this.databasePath))
            {
                using (SQLiteTransaction dbTransaction = dataConnection.BeginTransaction())
                {
                    using (SQLiteCommand dataCommand = dataConnection.CreateCommand())
                    {
                        dataCommand.Transaction = dbTransaction;
                        int sessionId = this.CreateDataUpdateSession(dataCommand);
                        int customerId = this.GetNextId(dataCommand, "Customer");
                        string query = $"INSERT INTO Customer(ID,SessionId,ALIAS,FIRSTNAME,LASTNAME)"
                             + $" VALUES ({customerId},{sessionId}, '{customer.Alias}','{customer.FirstName}','{customer.LastName}')";
                        SqliteDBHelper.ExecuteNonQuery(dataCommand, query);
                        customer.Id = customerId;
                    }

                    dbTransaction.Commit();
                }

                dataConnection.Close();
            }

            return customer;
        }

        private int CreateDataUpdateSession(SQLiteCommand dataCommand)
        {
            int nextSessionId = this.GetNextId(dataCommand, "DataUpdateSession");
            string updateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:SS.SSS");
            string query = $"INSERT INTO DataUpdateSession(ID,UpdateTime)"
                             + $" VALUES ({nextSessionId}, '{updateTime}')";
            SqliteDBHelper.ExecuteNonQuery(dataCommand, query);
            return nextSessionId;
        }

        public List<Customer> FindAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customer> FindAllCustomers(string alias)
        {
            throw new NotImplementedException();
        }

        public Customer FindCustomer(long customerId)
        {
            throw new NotImplementedException();
        }


    }
}
