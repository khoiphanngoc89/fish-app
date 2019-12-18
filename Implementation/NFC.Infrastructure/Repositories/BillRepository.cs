using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// Defines the bill repository.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.IGenericRepository{System.Int64, NFC.Domain.Entities.Bill}" />
    public interface IBillRepository : IGenericRepository<long, Bill>
    {
    }

    /// <summary>
    /// Provides bill repository methods.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.GenericRepositoryBase{System.Int64, NFC.Domain.Entities.Bill}" />
    /// <seealso cref="IBillRepository" />
    public class BillRepository : GenericRepositoryBase<long, Bill>, IBillRepository
    {
        public BillRepository(IRepository repository) : base(repository)
        {
        }
    }
}
