using Microsoft.Extensions.DependencyInjection;
using NFC.Common.Utility;
using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NFC.Application.DependencyManager
{
    public static class DependencyLoader
    {

        /// <summary>
        /// Called when [initialize].
        /// </summary>
        /// <param name="services">The services.</param>
        public static void InitializeInjection(this IServiceCollection services)
        {
            var files = FileHelper.GetDomainFiles(AppDomain.CurrentDomain.BaseDirectory);
            if (files.Any())
            {
                foreach (var file in files)
                {
                    InitializeHandling(services, AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(file));
                }
            }
        }

        /// <summary>
        /// Initializes the handling.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="dir">The dir.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <exception cref="TypeLoadException"></exception>
        public static void InitializeHandling(IServiceCollection services, string dir, string fileName)
        {
            var directoryCatalog = new DirectoryCatalog(dir, fileName);
            var imports = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(directoryCatalog);
                    using (var compositionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        var exports = compositionContainer.GetExports(imports);
                        var modules = exports.Select(export => export.Value as IDependencyResolver).Where(m => m != null);
                        var registerComponent = new DependencyRegister(services);
                        foreach (var module in modules)
                        {
                            module.OnInitialize(registerComponent);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in ex.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), ex);
            }
        }

        /// <summary>
        /// Builds the import definition.
        /// </summary>
        /// <returns></returns>
        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(def => true, typeof(IDependencyResolver).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }
}
