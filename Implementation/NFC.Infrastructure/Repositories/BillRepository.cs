using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// Defines the bill repository.
    /// </summary>
    public interface IBillRepository : IGenericRepository<long, Bill>
    {
    }

    /// <summary>
    /// Provides bill repository methods.
    /// </summary>
    /// <seealso cref="IBillRepository" />
    public class BillRepository : GenericRepositoryBase<long, Bill>, IBillRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        public BillRepository(IRepository repository) : base(repository)
        {
        }
    }
}
