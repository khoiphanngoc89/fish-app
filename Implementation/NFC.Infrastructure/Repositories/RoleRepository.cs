using NFC.Application.Shared;
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
    {/// <summary>
     /// Initializes a new instance of the <see cref="RoleRepository"/> class.
     /// </summary>
     /// <param name="repository">The data access object.</param>
     /// <param name="builder">The builder.</param>
        public RoleRepository(IRepository repository, IParamsBuilder builder) : base(repository, builder)
        {
        }
    }
}
