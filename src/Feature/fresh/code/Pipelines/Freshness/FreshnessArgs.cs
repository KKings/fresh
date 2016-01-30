namespace Sitecore.Feature.Freshness.Pipelines.Freshness
{
    using Data.Items;
    using Services;
    using Sitecore.Pipelines;

    public class FreshnessArgs : PipelineArgs
    {
        /// <summary>
        /// Gets the Item to resolve Freshness
        /// </summary>
        public Item Item { get; private set; }

        /// <summary>
        /// Gets or sets the freshness rating. This is the output of the pipeline
        /// </summary>
        public FreshnessRating FreshnessRating { get; set; }

        public FreshnessArgs(Item item)
        {
            this.Item = item;
        }
    }
}
