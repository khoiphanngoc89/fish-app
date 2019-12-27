using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.IGenericRepository{System.Int64, NFC.Domain.Entities.Role}" />
    public interface IRoleRepository : IGenericRepository<long, Role>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.GenericRepositoryBase{System.Int64, NFC.Domain.Entities.Role}" />
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
