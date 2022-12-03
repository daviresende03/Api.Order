using Order.Domain.Interfaces.Repositories;
using Order.Domain.Interfaces.Services;
using Order.Domain.Models;
using Order.Domain.Validations;
using Order.Domain.Validations.Base;

namespace Order.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Response> CreateAsync(ClientModel client)
        {
            var response = new Response();
            
            var validation = new ClientValidation();
            var errors = validation.Validate(client).GetErrors();

            if (errors.Report.Count > 0)
                return errors;

            await _clientRepository.CreateAsync(client);
            return response;
        }

        public async Task<Response> DeleteAsync(int clientId)
        {
            var response = new Response();
            return response;
        }

        public Task<Response<ClientModel>> GetByIdAsync(int clientId)
        {
            var response = new Response();
            return response;
        }

        public Task<Response<List<ClientModel>>> ListByFiltersAsync(int clientId = 0, string name = null)
        {
            var response = new Response();
            return response;
        }

        public Task<Response> UpdateAsync(ClientModel client)
        {
            var response = new Response();
            return response;
        }
    }
}
