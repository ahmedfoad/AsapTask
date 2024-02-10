using AsapTask.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsapTask.Clients.Dto
{
    public class ClientMapProfile : Profile
    {
        public ClientMapProfile()
        {
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();

        }
    }
}
