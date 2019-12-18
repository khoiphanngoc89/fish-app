using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NFC.Api.Config.Automapper;
using NFC.Api.Config.Cors;
using NFC.Api.Config.Jwt;
using NFC.Api.Config.Swagger;
using NFC.Api.Config.Validators;
using NFC.Application.DependencyManager;

namespace NFC.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
#if DEBUG
            //services.JwtConfig(this.Configuration["JwtToken:Issuer"], this.Configuration["JwtToken:SecretKey"]);
            services.SwaggerConfig();
#endif

#if !DEBUG
             services.JwtConfig(this.Configuration["JwtToken:ProdIssuer"]);
#endif
            services.AddCors(); // Make sure you call this previous to AddMvc

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
            services.ValidatorConfig();

            services.InitializeAutoMapper();
            services.InitializeInjection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Make sure you call this before calling app.UseMvc()
            app.CorsConfig();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseMvc();
        }
    }
}
