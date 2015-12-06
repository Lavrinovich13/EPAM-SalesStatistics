using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Handlers
{
    public class ClientHandler : ModelHandler<Client, EntityModels.Client>
    {
        protected IDataRepository<EntityModels.Client> _clientRepository = new ClientRepository();

        protected override Client EntityToModel(EntityModels.Client item)
        {
            return new Client() { Id = item.Id, LastName = item.LastName, FirstName = item.FirstName };
        }

        protected override EntityModels.Client ModelToEntity(Client item)
        {
            return new EntityModels.Client() { Id = item.Id, LastName = item.LastName, FirstName = item.FirstName };
        }

        protected override IDataRepository<EntityModels.Client> _repository
        {
            get
            {
                return _clientRepository;
            }
        }
    }
}
