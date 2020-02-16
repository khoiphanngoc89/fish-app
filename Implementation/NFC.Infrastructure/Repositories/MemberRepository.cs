using NFC.Application.Context;
using NFC.Application.Shared;
using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMemberRepository : IGenericRepository<long, Member>
    {
        /// <summary>
        /// Authenticates the user information.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Member Authenticate(string email, string password);
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
        /// <param name="builder">The builder.</param>
        public MemberRepository(IRepository repository, IParamsBuilder builder) : base(repository, builder)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Member Authenticate(string email, string password)
        {
            return this.SelectSingleOrDefault("Authenticate", this.paramsBuilder.Build(new AuthenticateContext
            {
                Email = email,
                Password = password
            }));
        }
    }
}
