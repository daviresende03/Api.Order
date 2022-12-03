using Order.Domain.Models;

namespace Order.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task CreateAsync(OrderModel order);
        Task CreateItemAsync(OrderItemModel item);
        Task UpdateAsync(OrderModel order);
        Task UpdateItemAsync(OrderItemModel item);
        Task DeleteAsync(int orderId);
        Task DeleteItemAsync(int orderId);
        Task<bool> ExistsByIdAsync(int orderId);
        Task<OrderModel> GetByIdAsync(int orderId);
        Task<List<OrderModel>> ListByFilterAsync(int id = 0, int clientId = 0, int userId = 0);
        Task<List<OrderItemModel>> ListItemsByFilterAsync(int orderId);
    }
}
