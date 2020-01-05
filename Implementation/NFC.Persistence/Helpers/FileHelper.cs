using System;
using System.IO;

namespace NFC.Persistence.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string GetImagePath(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
    }
}
