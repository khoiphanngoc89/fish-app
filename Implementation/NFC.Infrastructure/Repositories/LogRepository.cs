using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAppLogRepository : IGenericRepository<long, Log>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.Repositories.IAppLogRepository" />
    public class LogRepository : GenericRepositoryBase<long, Log>, IAppLogRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        public LogRepository(IRepository repository) : base(repository)
        {
        }
    }


}
