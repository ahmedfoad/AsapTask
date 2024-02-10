using AsapTask.Clients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AsapTask.Clients
{
    public interface IClientService :
         ICrudAppService< //Defines CRUD methods
        ClientDto, //Used to show books
        int, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        ClientDto> //Used to create/update a book
    {

    }
}
