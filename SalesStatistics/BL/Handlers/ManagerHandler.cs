using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DalModels = DAL.Models;
using BL.Models;
using DAL.Interfaces;
using DAL.Repositories;

namespace BL.Handlers
{
    public class ManagerHandler : ModelHandler<Manager, DalModels.Manager>
    {
        protected static IDataRepository<DalModels.Manager> _managerRepository = new ManagerRepository();

        public ManagerHandler()
        {
            Mapper.CreateMap<Manager, DalModels.Manager>();
            Mapper.CreateMap<DalModels.Manager, Manager>();
        }

        protected override IDataRepository<DalModels.Manager> _repository
        {
            get
            {
                return _managerRepository;
            }
        }

        protected override Manager ConvertToBlModel(DalModels.Manager item)
        {
            return Mapper.Map<DalModels.Manager, Manager>(item);
        }

        protected override DalModels.Manager ConvertToDalModel(Manager item)
        {
            return Mapper.Map<Manager, DalModels.Manager>(item);
        }
    }
}
