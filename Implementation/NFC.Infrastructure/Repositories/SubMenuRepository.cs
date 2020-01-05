using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System.Collections.Generic;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISubMenuRepository : IGenericRepository<int, SubMenu>
    {
        /// <summary>
        /// Gets the by parent identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IEnumerable<SubMenu> GetByParentId(int id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.Repositories.ISubMenuRepository" />
    public class SubMenuRepository : GenericRepositoryBase<int, SubMenu>, ISubMenuRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubMenuRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        public SubMenuRepository(IRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Gets the by parent identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<SubMenu> GetByParentId(int id)
        {
            return this.Select("GetSubMenuByParentId", new Dictionary<string, object>
            {
                ["@ParentId"] = id
            });
        }
    }
}
