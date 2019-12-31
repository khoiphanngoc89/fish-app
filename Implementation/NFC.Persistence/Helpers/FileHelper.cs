using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NFC.Persistence.Helpers
{
    public static class FileHelper
    {
        public static string GetImagePath(string path)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var path12 = Path.GetDirectoryName(basePath);
            return Path.Combine(basePath, path);
        }
    }
}
