using System.Collections.Generic;

namespace NFC.Application.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="NFC.Application.Contracts.IResponseResult{T}" />
    public class ResponseResult<T> : IResponseResult<T>
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public T Result { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public ICollection<object> Errors { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        public bool HasError => this.Errors?.Count > 0;

        /// <summary>
        /// Gets a value indicating whether this instance has success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has success; otherwise, <c>false</c>.
        /// </value>
        public bool HasSuccess => !this.HasError;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseResult{T}"/> class.
        /// </summary>
        public ResponseResult()
        {
            this.Errors = new List<object>();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResponseResult<T>
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        T Result { get; set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        ICollection<object> Errors { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        bool HasError { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has success; otherwise, <c>false</c>.
        /// </value>
        bool HasSuccess { get; }
    }
}
