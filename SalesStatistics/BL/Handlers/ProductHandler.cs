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
    public class ProductHandler : ModelHandler<Product, EntityModels.Product>
    {
        protected IDataRepository<EntityModels.Product> _productRepository = new ProductRepository();

        protected override Product EntityToModel(EntityModels.Product item)
        {
            return new Product() { Id = item.Id, Name = item.Name };
        }

        protected override EntityModels.Product ModelToEntity(Product item)
        {
            return new EntityModels.Product() { Id = item.Id, Name = item.Name };
        }

        protected override IDataRepository<EntityModels.Product> _repository
        {
            get
            {
                return _productRepository;
            }
        }
    }
}
