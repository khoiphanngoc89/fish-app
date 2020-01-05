using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoleRepository : IGenericRepository<long, Role>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.Repositories.IRoleRepository" />
    public class RoleRepository : GenericRepositoryBase<long, Role>, IRoleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        public RoleRepository(IRepository repository) : base(repository)
        {
        }
    }
}
