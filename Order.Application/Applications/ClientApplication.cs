using AutoMapper;
using Order.Application.DataContract.Request.Client;
using Order.Application.DataContract.Response.Client;
using Order.Application.Interfaces;
using Order.Domain.Interfaces.Services;
using Order.Domain.Models;
using Order.Domain.Validations.Base;

namespace Order.Application.Applications
{
    public class ClientApplication : IClientApplication
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientApplication(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        public async Task<Response> CreateAsync(CreateClientRequest client)
        {
            var clientModel = _mapper.Map<ClientModel>(client);

            return await _clientService.CreateAsync(clientModel);
        }

        public Task<Response> DeleteAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ClientResponse>> GetByIdAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ClientResponse>>> ListByFilterAsync(string clientId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(UpdateClientRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
