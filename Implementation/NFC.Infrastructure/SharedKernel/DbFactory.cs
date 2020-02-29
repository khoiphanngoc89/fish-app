using Microsoft.Extensions.Configuration;
using NFC.Common.Constants;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NFC.Infrastructure.SharedKernel
{
    /// <summary>
    /// Provices the database factory.
    /// </summary>
    public interface IDbFactory
    {
        /// <summary>
        /// Create connection to database.
        /// </summary>
        /// <returns></returns>
        IDbConnection CreateConnection();
    }

    /// <summary>
    /// Provides the connect to db.
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.SharedKernel.IDbFactory" />
    /// <seealso cref="System.IDisposable" />
    public class DbFactory : IDbFactory, IDisposable
    {
        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbFactory"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public DbFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Create connection to database.
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(this.configuration.GetConnectionString(Const.DefaultConnection));
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            this.disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DbFactory"/> class.
        /// </summary>
        ~DbFactory()
        {
            this.Dispose(false);
        }
    }
}
