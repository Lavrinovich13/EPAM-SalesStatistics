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
    public class ClientRepository : DataRepository<Client, EntityModels.Client>
    {
        public ClientRepository()
        {
            Mapper.CreateMap<Client, EntityModels.Client>();
            Mapper.CreateMap<EntityModels.Client, Client>();
        }

        protected override EntityModels.Client ConvertToEntity(Client item)
        {
            return Mapper.Map<Client, EntityModels.Client>(item); ;
        }

        protected override Client ConvertToObject(EntityModels.Client item)
        {
            return Mapper.Map<EntityModels.Client, Client>(item);
        }

        public override void Remove(Client item)
        {
            var client = ConvertToEntity(item);

            using (var context = new EntityModels.SalesDataBaseEntities())
            {
                context.Sales.RemoveRange(client.Sales);
                context.SaveChanges();
            }
            base.Remove(item);
        }
    }
}
