using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Common.Utility
{
    public static class Preconditions
    {
        public static void CheckNull<T>(T model, string description)
        {
            if(Equals(model, null))
            {
                throw new Exception($"{description} cannot be null");
            }
        }
    }
}
