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
    public class SaleRepository : DataRepository<Sale, EntityModels.Sale>
    {
        public SaleRepository()
        {
            Mapper.CreateMap<Sale, EntityModels.Sale>()
               .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.Client.Id))
               .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.Manager.Id))
               .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
               .ForMember(dest => dest.Client, opt => opt.Ignore())
               .ForMember(dest => dest.Product, opt => opt.Ignore())
               .ForMember(dest => dest.Manager, opt => opt.Ignore());

            Mapper.CreateMap<EntityModels.Sale, Sale>();
            Mapper.CreateMap<EntityModels.Client, Client>();
            Mapper.CreateMap<EntityModels.Manager, Manager>();
            Mapper.CreateMap<EntityModels.Product, Product>();
        }

        protected override EntityModels.Sale ConvertToEntity(Sale item)
        {
            return Mapper.Map<Sale, EntityModels.Sale>(item);
        }

        protected override Sale ConvertToObject(EntityModels.Sale item)
        {
           return Mapper.Map<EntityModels.Sale, Sale>(item);
        }
    }
}
