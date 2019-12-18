using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFC.Api.Config.Cors
{
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
