using AutoMapper;
using NFC.Domain.Entities;
using NFC.Infrastructure.Repositories;
using NFC.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFC.Persistence.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Persistence.Services.IService{System.Int32, NFC.Persistence.Contracts.MenuDto}" />
    public interface IMenuService : IService<int, MenuDto>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Persistence.Services.ServiceBase" />
    /// <seealso cref="NFC.Persistence.Services.IMenuService" />
    public class MenuService : ServiceBase, IMenuService
    {
        /// <summary>
        /// The menu repository
        /// </summary>
        private readonly IMenuRepository menuRepository;

        /// <summary>
        /// The sub menu repository
        /// </summary>
        private readonly ISubMenuRepository subMenuRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuService"/> class.
        /// </summary>
        /// <param name="menuRepository">The menu repository.</param>
        /// <param name="subMenuRepository">The sub menu repository.</param>
        /// <param name="mapper">The mapper.</param>
        public MenuService(IMenuRepository menuRepository, ISubMenuRepository subMenuRepository, IMapper mapper) : base(mapper)
        {
            this.menuRepository = menuRepository;
            this.subMenuRepository = subMenuRepository;
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public int Add(MenuDto model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all paging.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLastest">if set to <c>true</c> [get lastest].</param>
        /// <returns></returns>
        public IEnumerable<MenuDto> GetAllPaging(int pageNumber = 1, int pageSize = 30, bool getLatest = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all paging search.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="getLatest">if set to <c>true</c> [get latest].</param>
        /// <returns></returns>
        public IEnumerable<MenuDto> GetAllPagingSearch(string name, int pageNumber = 1, int pageSize = 30, bool getLatest = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public MenuDto GetById(int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="model">The model.</param>
        public void Update(int key, MenuDto model)
        {
            throw new NotImplementedException();
        }
    }
}
