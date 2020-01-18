using NFC.Persistence.Context;
using NFC.Persistence.Contracts;
using System;
using System.IO;
using Firebase.Storage;
using System.Threading.Tasks;

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
        Task UploadFile(UploadFileDto model);

        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        void Register(FireBaseContext context);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Persistence.Services.IFireBaseService" />
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
        /// The upload folder
        /// </summary>
        private const string UploadFolder = "Upload";

        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Register(FireBaseContext context)
        {
            this.apiKey = context.ApiKey;
            this.bucket = context.Bucket;
        }

        /// <summary>
        /// Uploads the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public Task UploadFile(UploadFileDto model)
        {
            if (model.FileContent.Length == 0 || string.IsNullOrWhiteSpace(model.FileName))
            {
                return new Task(null);
            }

            return Task.Run(async () =>
            {
                using (var stream = new MemoryStream(model.FileContent))
                {
                    var task = new FirebaseStorage(bucket)
                                .Child(UploadFolder)
                                .Child(model.FileName)
                                .PutAsync(stream);

                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
                    var downloadUrl = await task;
                }
            });

            
        }
    }
}

