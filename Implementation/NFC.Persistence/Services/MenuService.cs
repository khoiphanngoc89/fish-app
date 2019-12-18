using AutoMapper;
using NFC.Domain.Entities;
using NFC.Infrastructure.Repositories;
using NFC.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFC.Persistence.Services
{
    public class MenuService : ServiceBase, IService<int, MenuDTO>
    {
        private readonly IMenuRepository menuRepository;

        private readonly ISubMenuRepository subMenuRepository;

        public MenuService(IMenuRepository menuRepository, ISubMenuRepository subMenuRepository, IMapper mapper) : base(mapper)
        {
            this.menuRepository = menuRepository;
            this.subMenuRepository = subMenuRepository;
        }

        public int Add(MenuDTO model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuDTO> GetAll()
        {
            var menus = this.menuRepository.GetAll();
            foreach(var menu in menus)
            {
                if(!menu.HasSub)
                {
                    continue;
                }

                var subMenu = this.subMenuRepository.GetByParentId(menu.Id);
                menu.SubMenus.Add(subMenu);
            }

            return menus.Select(menu => this.mapper.Map<Menu, MenuDTO>(menu));
        }

        public IEnumerable<MenuDTO> GetAllPaging(int pageNumber = 1, int pageSize = 30, bool getLastest = false)
        {
            throw new NotImplementedException();
        }

        public MenuDTO GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(int key, MenuDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
