﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFC.Common.Extensions
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Determines whether [is null or empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>
        ///   <c>true</c> if [is null or empty] [the specified collection]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Any();
        }
    }
}