using ApplicationCore.Entities;
using AutoMapper;
using GlobalTour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTour
{
    public class GlobalTourMappingProfile:Profile
    {
        public GlobalTourMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ReverseMap();

            CreateMap<Product, ProductViewModel>()
                .ForMember(p=>p.ProductId,ex=>ex.MapFrom(i=>i.Id))
               .ReverseMap();
        }

            
    }
}
