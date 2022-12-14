using MySqlConnector;
using Order.Domain.Interfaces.Repositories.DataConnector;
using System.Data;

namespace Order.Infra.DataConnector
{
    public class MySqlConnector : IDbConnector
    {
        public IDbConnection dbConnection { get; }

        public IDbTransaction dbTransaction { get; set; }

        public MySqlConnector(string connectionString)
        {
            dbConnection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            dbConnection?.Dispose();
            dbTransaction?.Dispose();
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolation)
        {
            if(dbTransaction != null)
            {
                return dbTransaction;
            }

            if(dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            var dbtran = dbConnection.BeginTransaction(isolation);
            return dbtran;
        }
    }
}
