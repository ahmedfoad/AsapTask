using AsapTask.Clients.Dto;
using AsapTask.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace AsapTask.Clients
{
    public class ClientService : ApplicationService, IClientService
    {
        private readonly IRepository<Client, int> _clientRepository;
        private readonly IObjectMapper _objectMapper;

        public ClientService(IRepository<Client, int> clientRepository, IObjectMapper objectMapper)
        {
            _clientRepository = clientRepository;
            _objectMapper = objectMapper;
        }

        public async Task CreateAsync(ClientDto clientDto)
        {
            var client = ObjectMapper.Map<ClientDto, Client>(clientDto);
            await _clientRepository.InsertAsync(client);
        }

        public async Task UpdateAsync(int id, ClientDto clientDto)
        {
            var client = await _clientRepository.GetAsync(id);

            // Automatically set properties of the client object using the UpdateUserInput
            ObjectMapper.Map(clientDto, client);

            await _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        public async Task<List<ClientDto>> GetAllAsync()
        {
            var clients = await _clientRepository.ToListAsync();
            return _objectMapper.Map<List<Client>, List<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetAsync(int id)
        {
            var client = await _clientRepository.GetAsync(id);
            var clientDto = ObjectMapper.Map<Client, ClientDto>(client);
            return clientDto;
        }
    }
}
