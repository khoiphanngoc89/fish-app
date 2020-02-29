using Microsoft.AspNetCore.Builder;

namespace NFC.Api.Config.Cors
{
    /// <summary>
    /// 
    /// </summary>
    public static class Configure
    {
        /// <summary>
        /// Corses the configuration.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void CorsConfig(this IApplicationBuilder app)
        {

            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
        }
    }
}
