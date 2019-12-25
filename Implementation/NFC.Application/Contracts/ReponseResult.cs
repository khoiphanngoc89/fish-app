using System.Collections.Generic;

namespace NFC.Application.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public class ResponseResult<T> :IResponseResult<T>
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
        /// Initializes a new instance of the <see cref="ResponseResult"/> class.
        /// </summary>
        public ResponseResult()
        {
            this.Errors = new List<object>();
        }
    }

    public interface IResponseResult<T>
    {
        T Result { get; set; }

        ICollection<object> Errors { get; }

        bool HasError { get; }

        bool HasSuccess { get; }
    }
}
