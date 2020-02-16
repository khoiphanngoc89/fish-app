using NFC.Application.Shared;
using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBillDetailRepository : IGenericRepository<long, BillDetail>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.Repositories.IBillDetailRepository" />
    public class BillDetailRepository : GenericRepositoryBase<long, BillDetail>, IBillDetailRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillDetailRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        /// <param name="builder">The builder.</param>
        public BillDetailRepository(IRepository repository, IParamsBuilder builder) : base(repository, builder)
        {
        }
    }
}
