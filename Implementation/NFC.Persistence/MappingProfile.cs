using AutoMapper;
using NFC.Domain.Entities;
using NFC.Persistence.Contracts;
using NFC.Persistence.Helpers;
using System.Linq;

namespace NFC.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Menu, MenuDto>()
                .ForMember(dest => dest.Image, opts => opts.MapFrom(src => FileHelper.GetImagePath(src.Image)))
                .ForMember(dest => dest.SubMenus, opts => opts.MapFrom(src => src.SubMenus.Select(n => new SubMenuDto
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
