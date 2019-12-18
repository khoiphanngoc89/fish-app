using NFC.Common;
using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Infrastructure.Repositories
{
    public interface IAppLogRepository : IGenericRepository<long, Log>
    {
    }

    public class LogRepository : GenericRepositoryBase<long, Log>, IAppLogRepository
    {
        public LogRepository(IRepository repository) : base(repository)
        {
        }
    }

    
}
