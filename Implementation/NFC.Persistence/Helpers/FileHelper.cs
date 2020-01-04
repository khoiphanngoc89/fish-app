using System;
using System.IO;

namespace NFC.Persistence.Helpers
{
    public static class FileHelper
    {
        public static string GetImagePath(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
    }
}
