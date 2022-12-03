using Order.Application.DataContract.Request.Order;
using Order.Application.DataContract.Response.Order;
using Order.Domain.Validations.Base;

namespace Order.Application.Interfaces
{
    public interface IOrderApplication
    {
        Task<Response> CreateAsync(CreateOrderRequest orderRequest);
        Task<Response<List<OrderResponse>>> ListByFilterAsync(int orderId = 0, int clientId = 0, int userId = 0);
        Task<Response<OrderResponse>> GetByIdAsync(int orderId);
    }
}
