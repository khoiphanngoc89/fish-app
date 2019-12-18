using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    public interface IMemberRepository : IGenericRepository<long, Member>
    {
    }

    public class MemberRepository : GenericRepositoryBase<long, Member>, IMemberRepository
    {
        public MemberRepository(IRepository repository) : base(repository)
        {
        }
    }
}
