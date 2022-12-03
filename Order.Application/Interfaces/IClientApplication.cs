using Order.Application.DataContract.Request.Client;
using Order.Application.DataContract.Response.Client;
using Order.Domain.Validations.Base;

namespace Order.Application.Interfaces
{
    public interface IClientApplication
    {
        Task<Response> CreateAsync(CreateClientRequest client);
        Task<Response<List<ClientResponse>>> ListByFilterAsync(string clientId, string name);
        Task<Response<ClientResponse>> GetByIdAsync(string clientId);
        Task<Response> UpdateAsync(UpdateClientRequest request);
        Task<Response> DeleteAsync(string clientId);
    }
}
