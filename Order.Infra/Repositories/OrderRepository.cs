using Dapper;
using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Repositories.DataConnector;
using Order.Domain.Models;

namespace Order.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnector _dbConnector;
        const string baseSql = @"SELECT O.ID,
                                        O.CREATEDAT,
                                        O.CLIENTID AS ID,
                                        C.NAME,
                                        O.USERID AS ID,
                                        U.NAME
                                 FROM ORDER O
                                 JOIN CLIENT C ON O.CLIENTID = C.ID
                                 JOIN USER U ON O.USERID = U.ID";

        public OrderRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public async Task CreateAsync(OrderModel order)
        {
            string sql = @"INSERT INTO ORDER
                                    (ID,
                                     CLIENTID,
                                     USERID,
                                     CREATEDAT)
                            VALUES
                                    (@OrderId,
                                     @ClientId,
                                     @UserId,
                                     @CreatedAt);";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                OrderId = order.Id,
                ClientId = order.Client.Id,
                UserId = order.User.Id,
                CreatedAt = order.CreatedAt
            }, _dbConnector.dbTransaction);

            if (order.Items.Any())
            {
                foreach (var item in order.Items)
                {
                    await CreateItemAsync(item);
                }
            }
        }

        public async Task CreateItemAsync(OrderItemModel item)
        {
            string sql = @"INSERT INTO ORDERITEM
                                   (ID,
                                   ORDERID,
                                   PRODUCTID,
                                   SELLVALUE,
                                   QUANTITY,
                                   TOTALAMOUNT,
                                   CREATEDAT)
                             VALUES
                                   (@Id
                                   ,@OrderId
                                   ,@ProductId
                                   ,@SellValue
                                   ,@Quantity
                                   ,@TotalAmount
                                   ,@CreatedAt);";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = item.Id,
                OrderId = item.Order.Id,
                ProductId = item.Product.Id,
                SellValue = item.SellValue,
                Quantity = item.Quantity,
                TotalAmount = item.TotalAmount,
                CreatedAt = item.CreatedAt
            }, _dbConnector.dbTransaction);
        }

        public async Task DeleteAsync(int orderId)
        {
            string sql = $"DELETE FROM ORDER WHERE ID = @OrderId;";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { OrderId = orderId }, _dbConnector.dbTransaction);
        }

        public async Task DeleteItemAsync(int itemId)
        {
            string sql = $"DELETE FROM ORDERITEM WHERE ID = @ItemId;";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new { ItemId = itemId }, _dbConnector.dbTransaction);
        }

        public async Task<bool> ExistsByIdAsync(int orderId)
        {
            string sql = $"SELECT 1 FROM ORDER WHERE ID = @OrderId;";

            var existOrder = await _dbConnector.dbConnection.QueryAsync<bool>(sql, new { OrderId = orderId }, _dbConnector.dbTransaction);

            return existOrder.FirstOrDefault();
        }

        public async Task<OrderModel> GetByIdAsync(int orderId)
        {
            string sql = $"{baseSql} WHERE ID = @Id";

            var order = await _dbConnector.dbConnection.QueryAsync<OrderModel, ClientModel, UserModel, OrderModel>(
                sql: sql,
                map: (ord, client, user) =>
                {
                    ord.Client = client;
                    ord.User = user;
                    return ord;
                },
                param: new { Id = orderId },
                splitOn: "ID",
                transaction: _dbConnector.dbTransaction);

            return order.FirstOrDefault();
        }

        public async Task<List<OrderModel>> ListByFilterAsync(int id = 0, int clientId = 0, int userId = 0)
        {
            string sql = $"{baseSql}";

            if (id != 0)
            {
                sql += " WHERE O.ID = @OrderId";
            }
            if (clientId != 0)
            {
                if (!sql.Contains("WHERE"))
                {
                    sql += " WHERE O.CLIENTID = @ClientId";
                }
                else
                {
                    sql += " AND O.CLIENTID = @ClientId";
                }
            }
            if(userId != 0)
            {
                if (!sql.Contains("WHERE"))
                {
                    sql += " WHERE O.USERID = @UserId";
                }
                else
                {
                    sql += " AND O.USERID= @UserId";
                }
            }

            var order = await _dbConnector.dbConnection.QueryAsync<OrderModel, ClientModel, UserModel, OrderModel>(
                sql: sql,
                map: (ord, client, user) =>
                {
                    ord.Client = client;
                    ord.User = user;
                    return ord;
                },
                param: new { OrderId = id, ClientId = clientId, UserId = userId },
                splitOn: "ID",
                transaction: _dbConnector.dbTransaction);

            return order.ToList();
        }

        public async Task<List<OrderItemModel>> ListItemsByFilterAsync(int orderId)
        {
            string sql = @"SELECT OI.ID,
                                  OI.SELVALUE,
                                  OI.QUANTITY,
                                  OI.TOTALAMOUNT,
                                  OI.CREATEDAT,
                                  OI.ORDERID AS ID,
                                  OI.PRODUCTID AS ID,
                                  OI.DESCRIPTION
                            FROM ORDERITEM OI
                            JOIN PRODUCT P ON OI.PRODUCTID = P.ID
                            WHERE OI.ORDERID = @OrderId";
            var items = await _dbConnector.dbConnection.QueryAsync<OrderItemModel, OrderModel, ProductModel, OrderItemModel>(
                sql: sql,
                map: (item, order, prod) =>
                {
                    item.Order = order;
                    item.Product = prod;
                    return item;
                },
                param: new { OrderId = orderId },
                splitOn: "ID",
                transaction: _dbConnector.dbTransaction);

            return items.ToList();
        }

        public async Task UpdateAsync(OrderModel order)
        {
            string sql = @"UPDATE ORDER
                           SET CLIENTID = @ClientId,
                               USERID = @UserId
                           WHERE ID = @Id;";

            await _dbConnector.dbConnection.ExecuteAsync(sql, new
            {
                Id = order.Id,
                ClientId = order.Client.Id,
                UserId = order.User.Id
            }, _dbConnector.dbTransaction);

            if (order.Items.Any())
            {
                string sqlDeleteItems = @"DELETE FROM ORDERITEM WHERE ORDERID = @OrderId;";

                await _dbConnector.dbConnection.ExecuteAsync(sqlDeleteItems, new { OrderId = order.Id }, _dbConnector.dbTransaction);

                foreach(var item in order.Items)
                {
                    await CreateItemAsync(item);
                }
            }
        }
    }
}
