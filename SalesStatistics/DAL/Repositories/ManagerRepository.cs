using AutoMapper;
using DAL.AbstractRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ManagerRepository : DataRepository<Manager, EntityModels.Manager>
    {
        public ManagerRepository()
        {
            Mapper.CreateMap<Manager, EntityModels.Manager>();
            Mapper.CreateMap<EntityModels.Manager, Manager>();
        }

        protected override EntityModels.Manager ConvertToEntity(Manager item)
        {
            return Mapper.Map<Manager, EntityModels.Manager>(item);
        }

        protected override Manager ConvertToObject(EntityModels.Manager item)
        {
            return Mapper.Map<EntityModels.Manager, Manager>(item);
        }
    }
}
