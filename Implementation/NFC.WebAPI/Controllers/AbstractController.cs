using System;
using System.Data.SqlClient;
using System.IO;
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

        protected bool UploadFile(byte[] content, string filePath)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            var directory = Path.GetDirectoryName(fullPath);
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            try
            {
                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(content, 0, content.Length);
                    return true;
                }
            }
            catch
            {
                return false;
            }
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
            catch (SqlException ex)
            {
                response.Errors.Add(ex.Number);
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
            catch (SqlException ex)
            {
                response.Errors.Add(ex.Number);
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }
    }
}