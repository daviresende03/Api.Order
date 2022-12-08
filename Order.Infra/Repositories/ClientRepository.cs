using Dapper;
using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Repositories.DataConnector;
using Order.Domain.Models;

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

        public async Task CreateAsync(ClientModel client)
        {
            string sql = @"INSERT INTO CLIENT
                                    (ID,
                                     NAME,
                                     EMAIL,
                                     PHONENUMBER,
                                     ADRESS,
                                     CREATEDAT)
                                  VALUES
                                    (@Id,
                                     @Name,
                                     @Email,
                                     @PhoneNumber,
                                     @Adress,
                                     @CreatedAt);";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Adress = client.Adress,
                CreatedAt = client.CreatedAt
            }, _dbConnector.dbTransaction);
        }

        public async Task DeleteAsync(int clientId)
        {
            string sql = $"DELETE FROM CLIENT WHERE ID = @ClientId;";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { ClientId = clientId }, _dbConnector.dbTransaction);
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

        public async Task UpdateAsync(ClientModel client)
        {
            string sql = @"UPDATE CLIENT
                           SET NAME = @Name,
                               EMAIL = @Email,
                               PHONENUMBER = @PhoneNumber,
                               ADRESS = @Adress
                           WHERE ID = @ClientId";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                ClientId = client.Id,
                Name = client.Name,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Adress = client.Adress,
            }, _dbConnector.dbTransaction);
        }
    }
}
