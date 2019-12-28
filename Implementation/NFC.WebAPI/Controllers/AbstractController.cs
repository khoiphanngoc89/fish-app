using System;
using System.Data.Common;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFC.Application.Contracts;

namespace NFC.WebAPI.Controllers
{
    /// <summary>
    /// Provides the shared methods
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// <remarks>
    /// All methods in abstract controller should be protected.
    /// </remarks>
    public abstract class AbstractController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        protected readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        protected AbstractController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Executes action.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        protected static async Task<IResponseResult<object>> ExecuteAction<TResult>(Func<TResult> action)
        {
            return await Task.Run(() => OnExecuteAction(action));
        }

        /// <summary>
        /// Executes action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        protected static async Task<IResponseResult<object>> ExecuteAction(Action action)
        {
            return await Task.Run(() => OnExecuteAction(action));
        }

        /// <summary>
        /// Called when [execute action].
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private static IResponseResult<object> OnExecuteAction(Action action)
        {
            var response = new ResponseResult<object>();
            try
            {
                action();
            }
            catch (DbException ex)
            {
                response.Errors.Add(ex.ErrorCode);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Called when [execute action].
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private static IResponseResult<object> OnExecuteAction<TResult>(Func<TResult> action)
        {
            var response = new ResponseResult<object>();
            try
            {
                response.Result = action();
            }
            catch (DbException ex)
            {
                response.Errors.Add(ex.ErrorCode);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }
    }
}