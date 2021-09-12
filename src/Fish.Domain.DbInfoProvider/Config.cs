using Fish.Contact.Common;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fish.Domain.DbInfoProvider
{
    public static class Config
    {
        // client app: http://localhost:3006/
        //
        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client
            {
                ClientId = "identity-server-demo-web",
                AllowedGrantTypes = new List<string>
                {
                    GrantType.AuthorizationCode
                },
                RequireClientSecret = false,
                RequireConsent = false,
                RedirectUris = new List<string>
                { 
                    "http://localhost:3006/signin-callback.html"
                },
                PostLogoutRedirectUris = new List<string>
                { 
                    "http://localhost:3006/"
                },
                AllowedScopes = new List<string>
                {
                    Constant.ClientName,
                    "write",
                    "read",
                    "openid",
                    "profile",
                    "email"
                },
                AllowedCorsOrigins = new List<string>
                {
                    "http://localhost:3006",
                },
                AccessTokenLifetime = 86400
            }
        };

        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        {
            new ApiResource
            {
                Name = Constant.ClientName,
                DisplayName = "Identity Server Demo Api",
                Scopes = new List<string>
                {
                    "read",
                    "write"
                }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("openid"),
            new ApiScope("profile"),
            new ApiScope("email"),
            new ApiScope("read"),
            new ApiScope("write"),
            new ApiScope(Constant.ClientName)
        };
    }
}
