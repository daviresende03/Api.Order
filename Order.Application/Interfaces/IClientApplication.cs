using Order.Application.DataContract.Request.Client;
using Order.Application.DataContract.Response.Client;
using Order.Domain.Validations.Base;

namespace Order.Application.Interfaces
{
    public interface IClientApplication
    {
        Task<Response> CreateAsync(CreateClientRequest client);
        Task<Response<List<ClientResponse>>> ListByFilterAsync(int clientId=0, string name="");
        Task<Response<ClientResponse>> GetByIdAsync(int clientId);
        Task<Response> UpdateAsync(UpdateClientRequest request);
        Task<Response> DeleteAsync(int clientId);
    }
}
