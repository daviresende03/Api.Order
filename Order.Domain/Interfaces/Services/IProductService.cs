using Order.Domain.Models;

namespace Order.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task CreateAsync(ProductModel product);
        Task UpdateAsync(ProductModel product);
        Task DeleteAsync(int productId);
        Task<ProductModel> GetByIdAsync(int productId);
        Task<List<ProductModel>> ListByFilterAsync(int id = 0, string description = null);
    }
}
