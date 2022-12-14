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

        public Task<Response> DeleteAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<ClientResponse>> GetByIdAsync(int clientId)
        {
            Response<ClientModel> responseClientModel = await _clientService.GetByIdAsync(clientId);

            if (responseClientModel.Report.Any())
                return Response.Unprocessable<ClientResponse>(responseClientModel.Report);

            var response = _mapper.Map<ClientResponse>(responseClientModel.Data);
            return Response.Ok(response);
        }

        public async Task<Response<List<ClientResponse>>> ListByFilterAsync(int clientId=0, string name="")
        {
            Response<List<ClientModel>> clients = await _clientService.ListByFiltersAsync(clientId, name);

            if (clients.Report.Any())
                return Response.Unprocessable<List<ClientResponse>>(clients.Report);

            var response = _mapper.Map<List<ClientResponse>>(clients.Data);

            return Response.Ok(response);
        }

        public Task<Response> UpdateAsync(UpdateClientRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
