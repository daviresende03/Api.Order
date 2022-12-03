using Order.Domain.Interfaces.Services;
using Order.Domain.Models;

namespace Order.Domain.Services
{
    public class ProductService : IProductService
    {
        public Task CreateAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> ListByFilterAsync(int id = 0, string description = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
