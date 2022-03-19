using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Product , ProductToReturn>()
           .ForMember(x => x.ProductBrand , o => o.MapFrom(x => x.ProductBrand.Name))
           .ForMember(x => x.ProductType , o => o.MapFrom(x => x.ProductType.Name))
           .ForMember(d => d.PictureUrl , o => o.MapFrom<ProductUrlResolver>());

           CreateMap<Address , AddressDto>().ReverseMap();
           CreateMap<BasketItemDto , BasketItem>();
           CreateMap<CustomerBasketDto , CustomerBasket>();
          
        }
    }
}