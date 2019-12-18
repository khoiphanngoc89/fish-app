using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Application.Shared
{
    /// <summary>
    /// Defines the audi entity.
    /// </summary>
    public interface IAudiEntity
    {
        DateTime? CreationDate { get; set; }

        DateTime? ModifiedDate { get; set; }
    }
}
