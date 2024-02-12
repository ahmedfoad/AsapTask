using AsapTask.Clients.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AsapTask.Clients
{
    public interface IClientService : IApplicationService
    {
        Task CreateAsync(ClientDto clientDto);
        Task UpdateAsync(int id, ClientDto clientDto);
        Task DeleteAsync(int id);
        Task<ClientDto> GetAsync(int id);
        Task<List<ClientDto>> GetAllAsync();

    }
}
