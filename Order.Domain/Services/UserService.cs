using Order.Domain.Interfaces.Services;
using Order.Domain.Models;

namespace Order.Domain.Services
{
    public class UserService : IUserService
    {
        public Task<bool> AuthAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserModel>> ListByFilterAsync(int id = 0, string name = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
