using AutoMapper;
using System;
using System.Transactions;

namespace NFC.Persistence.Services
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        protected readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        protected ServiceBase(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// On service execute.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action">The function</param>
        /// <returns></returns>
        protected static TResult OnServiceExecute<TResult>(Func<TResult> action)
        {
            using var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var result = action.Invoke();
            scoped.Complete();
            return result;
        }

        /// <summary>
        ///  On service execute.
        /// </summary>
        /// <param name="action">The action.</param>
        protected static void OnServiceExecute(Action action)
        {
            using var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            action.Invoke();
            scoped.Complete();
        }
    }
}
