using Order.Domain.Models;
using Order.Domain.Validations.Base;

namespace Order.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<Response> CreateAsync(ClientModel client);
        Task<Response> UpdateAsync(ClientModel client);
        Task<Response> DeleteAsync(int clientId);
        Task<Response<ClientModel>> GetByIdAsync(int clientId);
        Task<Response<List<ClientModel>>> ListByFiltersAsync(int clientId=0,string name=null);
    }
}
