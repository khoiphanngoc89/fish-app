using NFC.Application.DependencyManager;
using NFC.Persistence.Services;
using System.ComponentModel.Composition;

namespace NFC.Persistence
{
    [Export(typeof(IDependencyResolver))]
    public class Resolver : IDependencyResolver
    {
        /// <summary>
        /// Called when [initialize].
        /// </summary>
        /// <param name="register">The register.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnInitialize(IDependencyRegister register)
        {
            register.AddTransient<IProductService, ProductService>();
            register.AddTransient<IMenuService, MenuService>();

        }
    }
}
