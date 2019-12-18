using System;
using System.Collections.Generic;
using System.Text;

namespace NFC.Application.DependencyManager
{
    public interface IDependencyRegister
    {
        /// <summary>
        /// Adds scoped.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        void AddScoped<TService>() where TService : class;

        /// <summary>
        /// Adds scoped
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void AddScoped<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        /// <summary>
        /// Adds singleton.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        void AddSingleton<TService>() where TService : class;

        /// <summary>
        /// Adds singleton.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void AddSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        /// <summary>
        /// Adds transient.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        void AddTransient<TService>() where TService : class;

        /// <summary>
        /// Adds transient.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void AddTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        /// <summary>
        /// Adds transient for mutiple implementation.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void AddTransient4MultiImplementation<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;

        /// <summary>
        /// Adds scoped for multiple implementation.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        void AddScoped4MultiImplementation<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;
    }
}
