using Order.Domain.Models;

namespace Order.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task CreateAsync(OrderModel order);
        Task UpdateAsync(OrderModel order);
        Task DeleteAsync(int orderId);
        Task<OrderModel> GetByIdAsync(int orderId);
        Task<List<OrderModel>> ListByFiltersAsync(int orderId = 0, int clientId = 0, int userId = 0);
    }
}
