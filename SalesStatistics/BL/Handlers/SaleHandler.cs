using BL.Interfaces;
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
    public class SaleHandler : ModelHandler<Sale, EntityModels.Sale>
    {
        protected IDataRepository<EntityModels.Sale> _saleRepository = new SaleRepository();

        protected IModelHandler<Manager> _managerHandler = new ManagerHandler();
        protected IModelHandler<Client> _clientHandler = new ClientHandler();
        protected IModelHandler<Product> _productHandler = new ProductHandler();

        protected override Sale EntityToModel(EntityModels.Sale item)
        {
            return new Sale()
            {
                Id = item.Id,
                Sum = item.Sum,
                Date = item.Date,
                Client = _clientHandler.FindInDb(item.ClientId),
                Manager = _managerHandler.FindInDb(item.ManagerId),
                Product = _productHandler.FindInDb(item.ProductId)
            };
        }

        protected override EntityModels.Sale ModelToEntity(Sale item)
        {
            return new EntityModels.Sale()
            {
                Id = item.Id,
                Date = item.Date,
                Sum = item.Sum,
                ClientId = item.Client.Id,
                ManagerId = item.Manager.Id,
                ProductId = item.Product.Id
            };
        }

        protected override IDataRepository<EntityModels.Sale> _repository
        {
            get
            {
                return _saleRepository;
            }
        }
    }
}
