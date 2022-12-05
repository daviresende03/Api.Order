using Order.Domain.Interfaces.Repositories.DataConnector;
using System.Data;

namespace Order.Infra.DataConnector
{
    internal class MySqlConnector : IDbConnector
    {
        public IDbConnection dbConnection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDbTransaction dbTransaction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
