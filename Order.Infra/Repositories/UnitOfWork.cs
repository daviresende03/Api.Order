using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Repositories.DataConnector;
using System.Data;

namespace Order.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IClientRepository _clientRepository;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        public IClientRepository ClientRepository => _clientRepository ?? (_clientRepository = new ClientRepository(dbConnector));

        public IOrderRepository OrderRepository => _orderRepository ?? (_orderRepository = new OrderRepository(dbConnector));

        public IProductRepository ProductRepository => _productRepository ?? (_productRepository = new ProductRepository(dbConnector));

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(dbConnector));

        public IDbConnector dbConnector { get; }

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
