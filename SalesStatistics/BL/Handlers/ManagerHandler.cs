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
    public class ManagerHandler : ModelHandler<Manager, EntityModels.Manager>
    {
        protected IDataRepository<EntityModels.Manager> _managerRepository = new ManagerRepository();

        protected override Manager EntityToModel(EntityModels.Manager item)
        {
            return new Manager() { Id = item.Id, LastName = item.LastName };
        }

        protected override EntityModels.Manager ModelToEntity(Manager item)
        {
            return new EntityModels.Manager() { Id = item.Id, LastName = item.LastName };
        }

        protected override IDataRepository<EntityModels.Manager> _repository
        {
            get 
            {
                return _managerRepository; 
            }
        }
    }
}
