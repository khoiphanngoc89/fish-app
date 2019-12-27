using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.IGenericRepository{System.Int32, NFC.Domain.Entities.Menu}" />
    public interface IMenuRepository : IGenericRepository<int, Menu>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.GenericRepositoryBase{System.Int32, NFC.Domain.Entities.Menu}" />
    /// <seealso cref="NFC.Infrastructure.Repositories.IMenuRepository" />
    public class MenuRepository : GenericRepositoryBase<int, Menu>, IMenuRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        public MenuRepository(IRepository repository) : base(repository)
        {
        }
    }
}
