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
    public class ProductRepository : DataRepository<Product, EntityModels.Product>
    {
        public ProductRepository()
        {
            Mapper.CreateMap<Product, EntityModels.Product>();
            Mapper.CreateMap<EntityModels.Product, Product>();
        }


        protected override EntityModels.Product ConvertToEntity(Product item)
        {
            return Mapper.Map<Product, EntityModels.Product>(item);
        }

        protected override Product ConvertToObject(EntityModels.Product item)
        {
            return Mapper.Map<EntityModels.Product, Product>(item);
        }
    }
}
