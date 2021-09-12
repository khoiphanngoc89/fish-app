using Fish.Contact.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish.Module.User
{
    public interface IUserService
    {
        Task<SignInResult> Login(Login login);

        Task<LogoutResult> Logout(string logoutId);

        Task<bool> Register(RegisterInfo register);
    }
}
