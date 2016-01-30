
namespace Sitecore.Feature.Freshness.Pipelines.ResolveItemBoost
{
    using ContentSearch.Pipelines.ResolveBoost.ResolveItemBoost;
    using Data.Items;
    using Diagnostics;
    using Freshness;
    using Sitecore.Pipelines;

    /// <summary>
    /// Boost the Indexed value of a content item based
    /// on the freshness factor
    /// </summary>
    public class BoostIndicator : BaseResolveItemBoostPipelineProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void Process(ResolveItemBoostArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            if (args.ResolvedBoost < 0
                || (args.ResolvedBoost > 0 && args.ResolvedBoost < 1))
            {
                return;
            }

            // Retrieve the indexed item from the IIndexable passed through pipeline arguments
            var item = (Item)(args.Indexable as ContentSearch.SitecoreIndexableItem);
            
            var freshnessArgs = new FreshnessArgs(item);

            CorePipeline.Run(Constants.FreshnessPipeline, freshnessArgs);

            var weight = (float)(freshnessArgs.FreshnessRating.Score/100) + 1;

            args.ResolvedBoost *= weight;
        }
    }
}
