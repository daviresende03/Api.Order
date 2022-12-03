﻿using Order.Domain.Interfaces.Repositories;
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

            var exists = await _clientRepository.ExistsByIdAsync(clientId);

            if (!exists)
            {
                response.Report.Add(Report.Create($"Client {clientId} not exists!"));
                return response;
            }

            await _clientRepository.DeleteAsync(clientId);
            return response;
        }

        public async Task<Response<ClientModel>> GetByIdAsync(int clientId)
        {
            var response = new Response<ClientModel>();
            var exists = await _clientRepository.ExistsByIdAsync(clientId);

            if (!exists)
            {
                response.Report.Add(Report.Create($"Client {clientId} not exists!"));
                return response;
            }

            response.Data = await _clientRepository.GetByIdAsync(clientId);
            return response;
        }

        public async Task<Response<List<ClientModel>>> ListByFiltersAsync(int clientId = 0, string name = null)
        {
            var response = new Response<List<ClientModel>>();
            if(!(clientId == 0))
            {
                var exists = await _clientRepository.ExistsByIdAsync(clientId);

                if (!exists)
                {
                    response.Report.Add(Report.Create($"Client {clientId} not exists!"));
                    return response;
                }
            }

            response.Data = await _clientRepository.ListByFilterAsync(clientId,name);
            return response;
        }

        public async Task<Response> UpdateAsync(ClientModel client)
        {
            var response = new Response();

            var validation = new ClientValidation();
            var errors = validation.Validate(client).GetErrors();

            if (errors.Report.Count > 0)
                return errors;

            var exists = await _clientRepository.ExistsByIdAsync(client.Id);

            if (!exists)
            {
                response.Report.Add(Report.Create($"Client {client.Id} not exists!"));
                return response;
            }

            await _clientRepository.UpdateAsync(client);
            return response;
        }
    }
}