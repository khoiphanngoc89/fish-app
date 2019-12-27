using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
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

            var _output = await Task.Factory.StartNew(async () =>
            {
                var expr = Expression.Invoke(action);
                Expression<Func<TResult>> lambda = Expression.Lambda<Func<TResult>>(expr);
                Func<TResult> compiled = lambda.Compile();
                var output = compiled.Invoke();
                return output;

            }).ConfigureAwait(false);

            if (!Equals(_output.Exception, null) && _output.Exception.InnerExceptions.Any())
            {
                // aa
                if (_output.Exception.InnerException is SqlException)
                {
                    response.Errors.Add((_output.Exception.InnerException as SqlException).Number);
                }
                else
                {
                    response.Errors.Add(_output.Exception.Message);
                }
            }
            else
            {
                response.Result = _output.Result;
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