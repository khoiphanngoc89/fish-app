using Fish.Contact.User;
using Fish.Domain.DbInfoProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Fish.Authen
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

            var connectionString = Configuration.GetConnectionString("IdentityServerDatabase");

            var authenAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var dbProviderAssembly = typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name;
            var userAssembly = typeof(AppUser).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly(dbProviderAssembly)
                                                             .MigrationsAssembly(userAssembly)
                                                             .MigrationsAssembly(authenAssembly)));

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddAspNetIdentity<AppUser>()
                    .AddConfigurationStore(options =>
                    {
                        options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(authenAssembly));
                    })
                    .AddOperationalStore(options =>
                    {
                        options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(authenAssembly));
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fish.Authen", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fish.Authen v1"));
            }

            app.UseRouting();
            context.Database.Migrate();
            DatabaseInitializer.PopulateIdentityServer(app);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseIdentityServer();
        }
    }
}
