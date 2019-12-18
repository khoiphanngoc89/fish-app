using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NFC.Common.Utility
{
    public static class FileHelper
    {
        /// <summary>
        /// Gets the domain files.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetDomainFiles(string directory)
        {
            var files = Directory.GetFiles(directory, "*.dll");
            return files.Where(n => Path.GetFileName(n).StartsWith("NFC."));
        }
    }
}
