using Fish.Contact.Common;
using Fish.Contact.User;
using IdentityModel;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fish.Module.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IIdentityServerInteractionService interaction;

        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IIdentityServerInteractionService interaction)
        {
            this.interaction = interaction;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> Login(Login login)
        {
            var context = await this.interaction.GetAuthorizationContextAsync(login.ReturnUrl);
            var result = await this.signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberLogin, lockoutOnFailure: true);
            if (result.Succeeded && !Equals(context, null))
            {
                return result;
            }

            throw new ArgumentException(Error.InvalidCredential);
        }

        public async Task<LogoutResult> Logout(string logoutId)
        {
            await this.signInManager.SignOutAsync();
            var logout = await this.interaction.GetLogoutContextAsync(logoutId);
            return (LogoutResult)logout;
        }

        public async Task<bool> Register(RegisterInfo info)
        {
            var user = new AppUser
            {
                UserName = info.Email,
                Email = info.Email,
                EmailConfirmed = true,
                PhoneNumber = info.PhoneNumber
            };

            var result = await this.userManager.CreateAsync(user, info.Password);

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            result = await this.userManager.AddClaimsAsync(user, new Claim[]
            {
                new Claim(JwtClaimTypes.Email, info.Email)
            });

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            return true;
        }
    }
}
