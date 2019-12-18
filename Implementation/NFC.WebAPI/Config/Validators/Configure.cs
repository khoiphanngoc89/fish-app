using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using NFC.WebAPI;

namespace NFC.Api.Config.Validators
{
    /// <summary>
    /// 
    /// </summary>
    public static class Configure
    {
        /// <summary>
        /// Validators the configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ValidatorConfig(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>()); ;
        }
    }
}
