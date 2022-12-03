using Order.Application.DataContract.Request.Client;
using Order.Domain.Validations.Base;

namespace Order.Application.Interfaces
{
    public interface IClientApplication
    {
        Task<Response> CreateAsync(CreateClientRequest client);
    }
}
