using Order.Domain.Models;

namespace Order.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task DeleteAsync(int userId);
        Task<bool> ExistsByIdAsync(int userId);
        Task<bool> ExistsByLoginAsync(string loginId);
        Task<UserModel> GetByIdAsync(int userId);
        Task<List<UserModel>> ListByFilterAsync(int id = 0, string name = null);
    }
}
