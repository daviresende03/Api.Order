using Dapper;
using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Repositories.DataConnector;
using Order.Domain.Models;
using System.Data;

namespace Order.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnector _dbConnector;
        const string baseSql = @"SELECT 
                                    ID,
                                    NAME,
                                    EMAIL,
                                    PHONENUMBER,
                                    ADRESS,
                                    CREATEDAT
                                  FROM CLIENT";

        public ClientRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public Task CreateAsync(ClientModel client)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByIdAsync(int clientId)
        {
            string sql = $"SELECT 1 FROM CLIENT WHERE ID = @Id";

            var existClient = (await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = "%" + clientId + "%" }, _dbConnector.dbTransaction)).FirstOrDefault();

            return existClient;
        }

        public async Task<ClientModel> GetByIdAsync(int clientId)
        {
            string sql = $"{baseSql} WHERE ID = @Id";
            
            var clients = await _dbConnector.dbConnection.QueryAsync<ClientModel>(sql, new { Id = "%" + clientId + "%" }, _dbConnector.dbTransaction);
            
            return clients.FirstOrDefault();
        }

        public async Task<List<ClientModel>> ListByFilterAsync(int id = 0, string name = null)
        {
            string sql = $"{baseSql}";

            if(id != 0)
            {
                sql += " WHERE ID = @Id";
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!sql.Contains("WHERE"))
                {
                    sql += " WHERE NAME LIKE @Name";
                }
                else
                {
                    sql += " AND NAME LIKE @Name";
                }
            }

            var clients = await _dbConnector.dbConnection.QueryAsync<ClientModel>(sql, new {Id = id, Name = '%'+name+'%'}, _dbConnector.dbTransaction);
            return clients.ToList();
        }

        public Task UpdateAsync(ClientModel client)
        {
            throw new NotImplementedException();
        }
    }
}
