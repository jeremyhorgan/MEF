using BIProvider;
using System.ComponentModel.Composition;

namespace Dundas
{
    [Export(typeof(IBIProvider))]
    [ExportMetadata("BIProvider", "DundasBI")]
    public class DundasBIProvider : IBIProvider
    {
        public string Name { get; private set; }

        public DundasBIProvider()
        {
            Name = "DundasBIProvider";
        }
    }
}