using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NFC.Api.Config.Automapper;
using NFC.Api.Config.Cors;
using NFC.Api.Config.Jwt;
using NFC.Api.Config.Swagger;
using NFC.Api.Config.Validators;
using NFC.Application.DependencyManager;

namespace NFC.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

#if DEBUG
            services.JwtConfig(this.Configuration["JwtSettings:Issuer"], this.Configuration["JwtSettings:SecretKey"]);
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

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </remarks>
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

            app.CorsConfig();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            // Make sure you call this before calling app.UseMvc()
            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "CatchAll", action = "Index" });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
