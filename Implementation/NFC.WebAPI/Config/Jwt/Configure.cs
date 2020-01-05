using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NFC.Common.Utility;

namespace NFC.Api.Config.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public static class Configure
    {
        /// <summary>
        /// JWTs the configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="issuer">The issuer.</param>
        /// <param name="secretKey">The secret key.</param>
        public static void JwtConfig(this IServiceCollection services, string issuer, string secretKey)
        {
            var tokenValidationParamters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(EncodeHelper.EncodeASCII(secretKey)),
                ValidateActor = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true,
                ValidIssuer = issuer,
                ValidAudience = issuer,
            };

            services.AddSingleton(tokenValidationParamters);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.SaveToken = true;
                     options.TokenValidationParameters = tokenValidationParamters;
                 });
        }
    }
}
