using Order.Domain.Models;

namespace Order.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task CreateAsync(ProductModel product);
        Task UpdateAsync(ProductModel product);
        Task DeleteAsync(int productId);
        Task<bool> ExistsByIdAsync(int productId);
        Task<ProductModel> GetByIdAsync(int productId);
        Task<List<ProductModel>> ListByFilterAsync(int id = 0, string name = null);
    }
}
