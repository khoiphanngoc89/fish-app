using System.Text;

namespace NFC.Common.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class EncodeHelper
    {
        /// <summary>
        /// Encodes the ASCII.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns bytes array.</returns>
        public static byte[] EncodeASCII(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
    }
}
