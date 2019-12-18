﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Application.Shared
{
    /// <summary>
    /// Defines the domain entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="NFC.Common.IDomainEntity{TKey}" />
    public abstract class DomainEntity<TKey> : IDomainEntity<TKey>
        where TKey : IComparable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public TKey Id { get; set; }

        /// <summary>
        /// Determines whether this instance is transient.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is transient; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTransient()
        {
            return Equals(this.Id, default(TKey));
        }
    }
}