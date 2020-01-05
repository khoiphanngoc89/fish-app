using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMemberRepository : IGenericRepository<long, Member>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.Repositories.IMemberRepository" />
    public class MemberRepository : GenericRepositoryBase<long, Member>, IMemberRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        public MemberRepository(IRepository repository) : base(repository)
        {
        }
    }
}
