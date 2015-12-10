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
using System.Reflection;

namespace BL.Handlers
{
    public class SaleHandler : ModelHandler<Sale, DalModels.Sale>
    {
        protected static IDataRepository<DalModels.Sale> _saleRepository = new SaleRepository();

         public SaleHandler()
        {
            Mapper.CreateMap<Sale, DalModels.Sale>();
            Mapper.CreateMap<DalModels.Sale, Sale>();

            Mapper.CreateMap<DalModels.Client, Client>();
            Mapper.CreateMap<DalModels.Product, Product>();
            Mapper.CreateMap<DalModels.Manager, Manager>();

            Mapper.CreateMap<Client, DalModels.Client>();
            Mapper.CreateMap<Product, DalModels.Product>();
            Mapper.CreateMap<Manager, DalModels.Manager>();
        }

         protected override IDataRepository<DalModels.Sale> _repository
        {
            get
            {
                return _saleRepository;
            }
        }

         protected override Sale ConvertToBlModel(DalModels.Sale item)
        {
            return Mapper.Map<DalModels.Sale, Sale>(item);
        }

         protected override DalModels.Sale ConvertToDalModel(Sale item)
        {
            return Mapper.Map<Sale, DalModels.Sale>(item);
        }
    }
}
