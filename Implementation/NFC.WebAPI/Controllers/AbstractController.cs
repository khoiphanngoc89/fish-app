using System;
using System.Data.Common;
using System.Linq.Expressions;
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
        protected static async Task<IResponseResult<object>> ExecuteAction<TResult>(Expression<Func<TResult>> action)
        {
            var response = new ResponseResult<object>();
            try
            {
                var _output = await Task.Factory.StartNew(() =>
                {
                    var expr = Expression.Invoke(action);
                    Expression<Func<TResult>> lambda = Expression.Lambda<Func<TResult>>(expr);
                    Func<TResult> compiled = lambda.Compile();
                    var output = compiled.Invoke();
                    return output;
                });

                response.Result = _output;

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
        /// Executes action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        protected static async Task<IResponseResult<object>> ExecuteAction(Expression<Action> action)
        {
            var response = new ResponseResult<object>();
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    var expr = Expression.Invoke(action);
                    Expression<Action> lambda = Expression.Lambda<Action>(expr);
                    var compiled = lambda.Compile();
                    compiled.Invoke();
                });

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