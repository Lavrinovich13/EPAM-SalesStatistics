using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalModels = DAL.Models;
using BL.Models;
using DAL.Interfaces;
using DAL.Repositories;

namespace BL.Handlers
{
    public class ClientHandler : ModelHandler<Client, DalModels.Client>
    {
        protected static IDataRepository<DalModels.Client> _clientRepository = new ClientRepository();

        public ClientHandler()
        {
            Mapper.CreateMap<Client, DalModels.Client>();
            Mapper.CreateMap<DalModels.Client, Client>();
        }

        protected override IDataRepository<DalModels.Client> _repository
        {
            get
            {
                return _clientRepository;
            }
        }

        protected override Client ConvertToBlModel(DalModels.Client item)
        {
            return Mapper.Map<DalModels.Client, Client>(item);
        }

        protected override DalModels.Client ConvertToDalModel(Client item)
        {
            return Mapper.Map<Client, DalModels.Client>(item);
        }
    }
}
