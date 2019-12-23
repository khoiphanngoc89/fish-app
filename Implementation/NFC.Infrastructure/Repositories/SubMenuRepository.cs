using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Infrastructure.Repositories
{
    public interface ISubMenuRepository : IGenericRepository<int, SubMenu>
    {
        SubMenu GetByParentId(int id);
    }

    public class SubMenuRepository : GenericRepositoryBase<int, SubMenu>, ISubMenuRepository
    {
        public SubMenuRepository(IRepository repository) : base(repository)
        {
        }

        public SubMenu GetByParentId(int id)
        {
            return this.SelectSingleOrDefault("GetSubMenuByParentId", new Dictionary<string, object>
            {
                ["@ParentId"] = id
            });
        }
    }
}
