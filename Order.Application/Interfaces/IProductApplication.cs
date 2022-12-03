using Order.Application.DataContract.Request.Product;
using Order.Application.DataContract.Response.Product;
using Order.Domain.Validations.Base;

namespace Order.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<Response> CreateAsync(CreateProductRequest productRequest);
        Task<List<ProductResponse>> ListByFilterAsync(int productId = 0, string description = null);
    }
}
