using Order.Domain.Models;

namespace Order.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task CreateAsync(ClientModel client);
        Task UpdateAsync(ClientModel client);
        Task DeleteAsync(int clientId);
        Task<ClientModel> GetByIdAsync(int clientId);
        Task<List<ClientModel>> ListByFiltersAsync(int clientId=0,string name=null);
    }
}
