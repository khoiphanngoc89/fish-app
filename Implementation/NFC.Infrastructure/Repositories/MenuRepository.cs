using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Infrastructure.Repositories
{
    public interface IMenuRepository : IGenericRepository<int, Menu>
    {
    }

    public class MenuRepository : GenericRepositoryBase<int, Menu>, IMenuRepository
    {
        public MenuRepository(IRepository repository) : base(repository)
        {
        }
    }
}
