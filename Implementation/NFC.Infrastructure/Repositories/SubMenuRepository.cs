using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Infrastructure.Repositories
{
    public interface ISubMenuRepository : IGenericRepository<int, SubMenu>
    {
        IEnumerable<SubMenu> GetByParentId(int id);
    }

    public class SubMenuRepository : GenericRepositoryBase<int, SubMenu>, ISubMenuRepository
    {
        public SubMenuRepository(IRepository repository) : base(repository)
        {
        }

        public IEnumerable<SubMenu> GetByParentId(int id)
        {
            return this.Select("GetSubMenuByParentId", new Dictionary<string, object>
            {
                ["@ParentId"] = id
            });
        }
    }
}
