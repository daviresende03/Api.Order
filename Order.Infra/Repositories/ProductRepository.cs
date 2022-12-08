using Dapper;
using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Repositories.DataConnector;
using Order.Domain.Models;

namespace Order.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnector _dbConnector;
        const string baseSql = @"SELECT ID,
                                        DESCRIPTION,
                                        SELLVALUE,
                                        STOCK,
                                        CREATEDAT
                                 FROM PRODUCT";

        public ProductRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public async Task CreateAsync(ProductModel product)
        {
            string sql = @"INSERT INTO PRODUCT
                                  VALUES(
                                  @Id,
                                  @Description,
                                  @SellValue,
                                  @Stock,
                                  @CreatedAt)";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = product.Id,
                Description = product.Description,
                SellValue = product.SellValue,
                Stock = product.Stock,
                CreatedAt = product.CreatedAt,
            }, _dbConnector.dbTransaction);
        }

        public async Task DeleteAsync(int productId)
        {
            string sql = $"DELETE FROM PRODUCT WHERE ID = @Id;";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new{ Id = productId }, _dbConnector.dbTransaction);
        }

        public async Task<bool> ExistsByIdAsync(int productId)
        {
            string sql = $"SELECT 1 FROM PRODUCT WHERE ID = @Id";

            var existProd = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { Id = productId }, _dbConnector.dbTransaction);

            return existProd.FirstOrDefault();
        }

        public async Task<ProductModel> GetByIdAsync(int productId)
        {
            string sql = $"{baseSql} WHERE ID = @Id";

            var product = await _dbConnector.dbConnection.QueryAsync<ProductModel>(sql, new { Id = productId }, _dbConnector.dbTransaction);

            return product.FirstOrDefault();
        }

        public async Task<List<ProductModel>> ListByFilterAsync(int id = 0, string name = null)
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
                    sql += " WHERE DESCRIPTION LIKE @Name";
                }
                else
                {
                    sql += " AND DESCRIPTION LIKE @Name";
                }
            }

            var product = await _dbConnector.dbConnection.QueryAsync<ProductModel>(sql, new { Id = id, Name = "%"+name+"%" }, _dbConnector.dbTransaction);

            return product.ToList();
        }

        public async Task UpdateAsync(ProductModel product)
        {
            string sql = @"UPDATE PRODUCT
                                SET DESCRIPTION = @Description,
                                    SELLVALUE = @SellValue,
                                    STOCK = @Stock
                                WHERE ID = @ProductId;";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                ProductId = product.Id,
                Description = product.Description,
                SellValue = product.SellValue,
                Stock = product.Stock
            }, _dbConnector.dbTransaction);
        }
    }
}
