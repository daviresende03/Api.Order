using Order.Domain.Interfaces.Services;
using Order.Domain.Models;

namespace Order.Domain.Services
{
    public class OrderService : IOrderService
    {
        public Task CreateAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderModel>> ListByFiltersAsync(int orderId = 0, int clientId = 0, int userId = 0)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}
