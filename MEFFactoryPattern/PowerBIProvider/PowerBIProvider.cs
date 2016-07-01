using BIProvider;
using System.ComponentModel.Composition;

namespace PowerBI
{
    [Export(typeof(IBIProvider))]
    [ExportMetadata("BIProvider", "PowerBI")]
    public class PowerBIProvider : IBIProvider
    {
        public string Name { get; private set; }

        public PowerBIProvider()
        {
            Name = "PowerBIProvider";
        }
    }
}