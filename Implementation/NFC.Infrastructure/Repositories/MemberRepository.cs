using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMemberRepository : IGenericRepository<long, Member>
    {
        Member Authenticate(string username, string password);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Member Authenticate(string username, string password)
        {
            return this.SelectSingleOrDefault("Authenticate", this.BuildParmas())
        }
    }
}
