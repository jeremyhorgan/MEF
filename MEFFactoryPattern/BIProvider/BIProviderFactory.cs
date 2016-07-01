using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BIProvider
{
    public class BIProviderFactory
    {
        [ImportMany(typeof(IBIProvider))]
        public IEnumerable<Lazy<IBIProvider, IBIProviderMetaData>> _providers;
        
        private static BIProviderFactory _instance = new BIProviderFactory();

        private BIProviderFactory()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.CreateDirectory(path);

            var providersPath = Path.Combine(path, "BIProviders");
            var directoryCatalog = new DirectoryCatalog(providersPath, "*.dll");

            var container = new CompositionContainer(directoryCatalog);

            try
            {
                _providers = container.GetExports<IBIProvider, IBIProviderMetaData>();
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        private IBIProvider CreateProvider(string typename)
        {
            var provider = _providers.Where(p => p.Metadata.BIProvider == typename).FirstOrDefault();
            return provider?.Value;
        }

        public static IBIProvider Create(string typename)
        {
            return _instance.CreateProvider(typename);
        }
    }
}
