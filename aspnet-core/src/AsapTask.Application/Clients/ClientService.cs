using AsapTask.Clients.Dto;
using AsapTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AsapTask.Clients
{
    public class ClientService :
         CrudAppService<
        Client, //The Book entity
        ClientDto, //Used to show books
        int, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        ClientDto>, //Used to create/update a book
    IClientService //implement the IBookAppService
    {
        public ClientService(IRepository<Client, int> repository)
        : base(repository)
        {

        }
    }
}
