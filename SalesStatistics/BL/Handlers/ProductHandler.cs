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
    public class ProductHandler : ModelHandler<Product, DalModels.Product>
    {
        protected static IDataRepository<DalModels.Product> _productRepository = new ProductRepository();

        public ProductHandler()
        {
            Mapper.CreateMap<Product, DalModels.Product>();
            Mapper.CreateMap<DalModels.Product, Product>();
        }

        protected override IDataRepository<DalModels.Product> _repository
        {
            get
            {
                return _productRepository;
            }
        }

        protected override Product ConvertToBlModel(DalModels.Product item)
        {
            return Mapper.Map<DalModels.Product, Product>(item);
        }

        protected override DalModels.Product ConvertToDalModel(Product item)
        {
            return Mapper.Map<Product, DalModels.Product>(item);
        }
    }
}
