using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;

namespace NFC.Api.Config.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public static class Configure
    {
        /// <summary>
        /// Swaggers the configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void SwaggerConfig(this IServiceCollection services)
        {
            services.AddOpenApiDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "NFC";
                    document.Info.Description = "Ecommerce ASP.NET Core web API";

                };
                config.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                config.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));

            });
        }
    }
}
