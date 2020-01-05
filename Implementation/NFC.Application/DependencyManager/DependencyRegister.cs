using Microsoft.Extensions.DependencyInjection;

namespace NFC.Application.DependencyManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Application.DependencyManager.IDependencyRegister" />
    public class DependencyRegister : IDependencyRegister
    {
        /// <summary>
        /// The services.
        /// </summary>
        private readonly IServiceCollection services;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyRegister"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public DependencyRegister(IServiceCollection services)
        {
            this.services = services;
        }

        /// <summary>
        /// Adds scoped.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        public void AddScoped<TService>() where TService : class
        {
            this.services.AddScoped<TService>();
        }

        /// <summary>
        /// Adds singleton.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        public void AddSingleton<TService>() where TService : class
        {
            this.services.AddSingleton<TService>();
        }

        /// <summary>
        /// Adds transient.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        public void AddTransient<TService>() where TService : class
        {
            this.services.AddTransient<TService>();
        }

        /// <summary>
        /// Adds scoped
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void IDependencyRegister.AddScoped<TService, TImplementation>()
        {
            this.services.AddTransient<TService, TImplementation>();
        }

        /// <summary>
        /// Adds scoped for mutiple implementation.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void IDependencyRegister.AddScoped4MultiImplementation<TService, TImplementation>()
        {
            this.services.AddScoped<TImplementation>().
                AddScoped<TService, TImplementation>(s => s.GetService<TImplementation>());
        }

        /// <summary>
        /// Adds singleton.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void IDependencyRegister.AddSingleton<TService, TImplementation>()
        {
            this.services.AddSingleton<TService, TImplementation>();
        }

        /// <summary>
        /// Adds transient.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void IDependencyRegister.AddTransient<TService, TImplementation>()
        {
            this.services.AddTransient<TService, TImplementation>();
        }

        /// <summary>
        /// Adds transient for multiple implementation.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void IDependencyRegister.AddTransient4MultiImplementation<TService, TImplementation>()
        {
            this.services.AddTransient<TImplementation>().
                AddTransient<TService, TImplementation>(s => s.GetService<TImplementation>());
        }
    }
}
