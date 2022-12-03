using Order.Domain.Models;

namespace Order.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> AuthAsync(UserModel user);
        Task CreateAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task DeleteAsync(int userId);
        Task<UserModel> GetByIdAsync(int userId);
        Task<List<UserModel>> ListByFilterAsync(int id = 0, string name = null);
    }
}
