using AutoMapper;
using NFC.Domain.Entities;
using NFC.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Persistence
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<MenuDTO, Menu>().ReverseMap();
        }
    }
}
