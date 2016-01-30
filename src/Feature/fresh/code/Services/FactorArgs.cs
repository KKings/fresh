
namespace Sitecore.Feature.Indicator.Services
{
    using Data.Items;

    /// <summary>
    /// Arguments for resolving a factor
    /// </summary>
    public class FactorArgs
    {
        /// <summary>
        /// Gets the Item
        /// </summary>
        public Item Item { get; private set; }

        public FactorArgs(Item item)
        {
            this.Item = item;
        }
    }
}
