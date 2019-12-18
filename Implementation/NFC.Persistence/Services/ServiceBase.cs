using AutoMapper;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.Text;

namespace NFC.Persistence.Services
{
    public abstract class ServiceBase
    {
        protected readonly IMapper mapper;

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
            try
            {
                using (var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var result = action.Invoke();
                    scoped.Complete();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  On service execute.
        /// </summary>
        /// <param name="action">The action.</param>
        protected static void OnServiceExecute(Action action)
        {
            try
            {
                using (var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    action.Invoke();
                    scoped.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
