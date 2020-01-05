using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NFC.Common.Utility;
using System;
using System.Linq;
using System.Reflection;

namespace NFC.Api.Config.Automapper
{
    /// <summary>
    /// Provides automapper config.
    /// </summary>
    /// <remarks>
    /// https://long2know.com/2017/10/net-core-factory-pattern-for-multiple-mappers-automapper/?fbclid=IwAR2boZn-0x3is9naWaT7CXuiElnjEfVKQrN80z24PG11rKasuvkEbzgfjco
    /// </remarks>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Loads automapper.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            var files = FileHelper.GetDomainFiles(AppDomain.CurrentDomain.BaseDirectory);
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = true;

                foreach (var file in files)
                {
                    // https://stackoverflow.com/questions/18483354/get-assembly-of-program-from-a-dll
                    var assembly = Assembly.Load(file);
                    var types = assembly.GetTypes().Where(x => x.GetTypeInfo().IsClass && x.IsAssignableFrom(x) && x.GetTypeInfo().BaseType == typeof(Profile)).ToList();
                    foreach (var type in types)
                    {
                        var profile = (Profile)Activator.CreateInstance(type);
                        cfg.AddProfile(profile);
                    }
                }
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
