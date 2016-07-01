using BIProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = BIProviderFactory.Create("PowerBI");
            Console.WriteLine(provider.Name);
        }
    }
}
