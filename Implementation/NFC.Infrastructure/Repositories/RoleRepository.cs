using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Infrastructure.Repositories
{
    public interface IRoleRepository : IGenericRepository<long, Role>
    {
    }

    public class RoleRepository : GenericRepositoryBase<long, Role>, IRoleRepository
    {
        public RoleRepository(IRepository repository) : base(repository)
        {
        }
    }
}
