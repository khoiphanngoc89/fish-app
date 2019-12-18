using NFC.Application.DependencyManager;
using NFC.Infrastructure.Repositories;
using NFC.Infrastructure.SharedKernel;
using System.ComponentModel.Composition;

namespace NFC.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Application.DependencyManager.IDependencyResolver" />
    [Export(typeof(IDependencyResolver))]
    public class Resolver : IDependencyResolver
    {
        /// <summary>
        /// Called when [initialize].
        /// </summary>
        /// <param name="register">The register.</param>
        public void OnInitialize(IDependencyRegister register)
        {
            register.AddTransient<IBillDetailRepository, BillDetailRepository>();
            register.AddTransient<IBillRepository, BillRepository>();
            register.AddTransient<IMemberRepository, MemberRepository>();
            register.AddTransient<IMenuRepository, MenuRepository>();
            register.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            register.AddTransient<IProductRepository, ProductRepository>();
            register.AddTransient<IAppLogRepository, LogRepository>();
            register.AddTransient<IProductRepository, ProductRepository>();
            register.AddSingleton<IDbFactory, DbFactory>();
            register.AddTransient<IRepository, Repository>();
            
        }
    }
}
