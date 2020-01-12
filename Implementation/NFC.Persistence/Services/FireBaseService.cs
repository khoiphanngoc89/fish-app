using NFC.Persistence.Context;
using NFC.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Persistence.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFireBaseService
    {
        /// <summary>
        /// Uploads the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Upload(UploadFileDto model);

        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        void Register(FireBaseContext context);
    }

    /// <summary>
    /// 
    /// </summary>
    public class FireBaseService : IFireBaseService
    {
        /// <summary>
        /// The API key
        /// </summary>
        private string apiKey = "AIzaSyDfLO47zzdk3Ayz_X3kJhTIdH-p-CB0AEo";

        /// <summary>
        /// The bucket
        /// </summary>
        private string bucket = "fish-d3e4f.appspot.com";

        /// <summary>
        /// The authentication scheme
        /// </summary>
        private string authScheme = "hachiphan05@gmail.com";

        /// <summary>
        /// The authentication password
        /// </summary>
        private static readonly string authPassword = "@Ubm-09-09-1028";

        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Register(FireBaseContext context)
        {
            this.apiKey = context.ApiKey;
            this.bucket = context.Bucket;
            this.authScheme = context.AuthScheme;
        }

        public void Upload(UploadFileDto model)
        {

        }
    }
}
