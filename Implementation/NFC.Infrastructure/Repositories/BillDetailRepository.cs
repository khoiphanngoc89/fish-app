using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// Defines the bill detail repository.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.IGenericRepository{System.Int64, NFC.Domain.Entities.BillDetail}" />
    public interface IBillDetailRepository : IGenericRepository<long, BillDetail>
    {
    }

    /// <summary>
    /// Provides bill detail repository methods.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.GenericRepositoryBase{System.Int64, NFC.Domain.Entities.BillDetail}" />
    /// <seealso cref="IBillDetailRepository" />
    public class BillDetailRepository : GenericRepositoryBase<long, BillDetail>, IBillDetailRepository
    {
        public BillDetailRepository(IRepository repository) : base(repository)
        {
        }
    }
}
