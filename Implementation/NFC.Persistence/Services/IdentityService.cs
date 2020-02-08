using AutoMapper;
using NFC.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Persistence.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIdentityService
    {
        IdentityDto Authorization(string email, string password);
    }


    /// <summary>
    /// 
    /// </summary>
    public class IdentityService : ServiceBase, IIdentityService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public IdentityService(IMapper mapper) : base(mapper)
        {
           
        }

        public IdentityDto Authorization(string email, string password)
        {

            return new IdentityDto();
        }
    }
}
