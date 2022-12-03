using AutoMapper;
using Order.Application.DataContract.Request.Client;
using Order.Application.DataContract.Request.Order;
using Order.Application.DataContract.Request.Product;
using Order.Application.DataContract.Request.User;
using Order.Application.DataContract.Response.Client;
using Order.Application.DataContract.Response.Order;
using Order.Application.DataContract.Response.Product;
using Order.Application.DataContract.Response.User;
using Order.Domain.Models;

namespace Order.Application.Mapper
{
    public class Core : Profile
    {
        public Core()
        {
            ClientMap();
        }

        private void ClientMap()
        {
            // Client
            CreateMap<CreateClientRequest, ClientModel>();
            CreateMap<UpdateClientRequest, ClientModel>();
            CreateMap<ClientModel, ClientResponse>();

            // User
            CreateMap<CreateUserRequest, UserModel>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(y => y.Password));
            CreateMap<UserModel, UserResponse>();

            // Order
            CreateMap<CreateOrderRequest, OrderModel>()
                .ForPath(x => x.Client.Id, opt => opt.MapFrom(y => y.ClientId))
                .ForPath(x => x.User.Id, opt => opt.MapFrom(y => y.UserId));
            CreateMap<OrderModel, OrderResponse>()
                .ForMember(x => x.ClientId, opt => opt.MapFrom(y => y.Client.Id))
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.User.Id));

            // OrderItem
            CreateMap<CreateOrderItemRequest, OrderItemModel>()
               .ForPath(target => target.Product.Id, opt => opt.MapFrom(source => source.ProductId));
            CreateMap<OrderItemModel, OrderItemResponse>()
                .ForMember(target => target.ProductId, opt => opt.MapFrom(source => source.Product.Id));

            // Product
            CreateMap<CreateProductRequest, ProductModel>();
            CreateMap<ProductModel, ProductResponse>();
        }
    }
}
