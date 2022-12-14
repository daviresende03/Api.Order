using Order.Domain.Models;

namespace Order.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task CreateAsync(ClientModel client);
        Task UpdateAsync(ClientModel client);
        Task DeleteAsync(int clientId);
        Task<bool> ExistsByIdAsync(int clientId);
        Task<ClientModel> GetByIdAsync(int clientId);
        Task<List<ClientModel>> ListByFilterAsync(string name);
    }
}
