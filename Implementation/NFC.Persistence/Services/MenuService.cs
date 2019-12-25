using AutoMapper;
using NFC.Domain.Entities;
using NFC.Infrastructure.Repositories;
using NFC.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFC.Persistence.Services
{
    public interface IMenuService : IService<int, MenuDto>
    {

    }

    public class MenuService : ServiceBase, IMenuService
    {
        private readonly IMenuRepository menuRepository;

        private readonly ISubMenuRepository subMenuRepository;

        public MenuService(IMenuRepository menuRepository, ISubMenuRepository subMenuRepository, IMapper mapper) : base(mapper)
        {
            this.menuRepository = menuRepository;
            this.subMenuRepository = subMenuRepository;
        }

        public int Add(MenuDto model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuDto> GetAll()
        {
            var menus = this.menuRepository.GetAll();
            foreach(var menu in menus)
            {
                if(!menu.HasSub)
                {
                    continue;
                }

                var subMenus = this.subMenuRepository.GetByParentId(menu.Id);
                subMenus.ToList().ForEach(n => menu.SubMenus.Add(n));
            }

            return menus.Select(menu => this.mapper.Map<Menu, MenuDto>(menu));
        }

        public IEnumerable<MenuDto> GetAllPaging(int pageNumber = 1, int pageSize = 30, bool getLastest = false)
        {
            throw new NotImplementedException();
        }

        public MenuDto GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(int key, MenuDto model)
        {
            throw new NotImplementedException();
        }
    }
}
