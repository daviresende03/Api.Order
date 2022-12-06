using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Repositories.DataConnector;
using System.Data;

namespace Order.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IClientRepository _clientRepository;
        public IClientRepository ClientRepository => _clientRepository ?? (_clientRepository = new ClientRepository(dbConnector));

        public IOrderRepository OrderRepository => throw new NotImplementedException();

        public IProductRepository ProductRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => throw new NotImplementedException();

        public IDbConnector dbConnector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BeginTransaction()
        {
            dbConnector.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void CommitTransaction()
        {
            if (dbConnector.dbConnection.State == ConnectionState.Open)
            {
                dbConnector.dbTransaction.Commit();
            }
        }

        public void RoolbackTransaction()
        {
            if (dbConnector.dbConnection.State == ConnectionState.Open)
            {
                dbConnector.dbTransaction.Rollback();
            }
        }
    }
}
