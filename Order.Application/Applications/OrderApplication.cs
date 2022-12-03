using AutoMapper;
using Order.Application.DataContract.Request.Order;
using Order.Application.DataContract.Response.Order;
using Order.Application.Interfaces;
using Order.Domain.Interfaces.Services;
using Order.Domain.Validations.Base;

namespace Order.Application.Applications
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderApplication(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public Task<Response> CreateAsync(CreateOrderRequest orderRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Response<OrderResponse>> GetByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<OrderResponse>>> ListByFilterAsync(int orderId = 0, int clientId = 0, int userId = 0)
        {
            throw new NotImplementedException();
        }
    }
}
