using Dapper;
using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Repositories.DataConnector;
using Order.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnector _dbConnector;
        const string baseSql = @"SELECT ID,
                                        NAME,
                                        LOGIN,
                                        PASSWORDHASH,
                                        CREATEDAT,
                                 FROM USER";

        public UserRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public async Task CreateAsync(UserModel user)
        {
            string sql = @"INSERT INTO USER
                                  VALUES(
                                    @Id,
                                    @Name,
                                    @Login,
                                    @PasswordHash,
                                    @CreatedAt);";


            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                PasswordHash = user.PasswordHash,
                CreatedAt = user.CreatedAt
            }, _dbConnector.dbTransaction);
        }

        public async Task UpdateAsync(UserModel user)
        {
            string sql = @"UPDATE USER
                             SET NAME = @Name,
                                 LOGIN = @Login,
                                 PASSWORDHASH = @PasswordHash
                             WHERE ID = @Id ";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                PasswordHash = user.PasswordHash
            }, _dbConnector.dbTransaction);
        }

        public async Task DeleteAsync(int userId)
        {
            string sql = $"DELETE FROM [dbo].[User] WHERE id = @id";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { Id = userId }, _dbConnector.dbTransaction);
        }

        public async Task<bool> ExistsByIdAsync(int userId)
        {
            string sql = $"SELECT 1 FROM USER WHERE ID = @Id ";

            var existUser = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = userId }, _dbConnector.dbTransaction);

            return existUser.FirstOrDefault();
        }

        public async Task<bool> ExistsByLoginAsync(string login)
        {
            string sql = $"SELECT 1 FROM USER WHERE LOGIN = @Login ";

            var existUser = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Login = login }, _dbConnector.dbTransaction);

            return existUser.FirstOrDefault();
        }

        public async Task<UserModel> GetByIdAsync(int userId)
        {
            string sql = $"{baseSql} AND ID = @Id";

            var users = await _dbConnector.dbConnection.QueryAsync<UserModel>(sql, new { Id = userId }, _dbConnector.dbTransaction);

            return users.FirstOrDefault();
        }

        public async Task<List<UserModel>> ListByFilterAsync(int id = 0, string name = null)
        {
            string sql = $"{baseSql} ";
            
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

            var users = await _dbConnector.dbConnection.QueryAsync<UserModel>(sql, new { Login = id, Name = "%"+name+"%" }, _dbConnector.dbTransaction);

            return users.ToList();
        }
    }
}
