using System;

namespace NFC.Common.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class Preconditions
    {
        /// <summary>
        /// Checks the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <param name="description">The description.</param>
        /// <exception cref="Exception"></exception>
        public static void CheckNull<T>(T model, string description)
        {
            if(Equals(model, null))
            {
                throw new Exception($"{description} cannot be null");
            }
        }
    }
}
