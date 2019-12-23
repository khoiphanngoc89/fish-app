using AutoMapper;
using NFC.Domain.Entities;
using NFC.Persistence.Contracts;
using System.Linq;

namespace NFC.Persistence
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<Menu, MenuDTO>()
                .ForMember(dest => dest.SubMenus, opts => opts.MapFrom(src => src.SubMenus.Select(n => new SubMenuDTO
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    IsActive = n.IsActive,
                    ParentId = n.ParentId,
                    Url = n.Url
                })));
        }
    }
}
