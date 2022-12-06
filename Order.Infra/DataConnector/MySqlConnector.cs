using MySqlConnector;
using Order.Domain.Interfaces.Repositories.DataConnector;
using System.Data;

namespace Order.Infra.DataConnector
{
    internal class MySqlConnector : IDbConnector
    {
        public IDbConnection dbConnection { get; }

        public IDbTransaction dbTransaction { get; }
        IDbTransaction IDbConnector.dbTransaction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
