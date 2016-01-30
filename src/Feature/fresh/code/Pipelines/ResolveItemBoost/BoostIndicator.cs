
namespace Sitecore.Feature.Indicator.Pipelines.ResolveItemBoost
{
    using ContentSearch.Pipelines.ResolveBoost.ResolveItemBoost;
    using Diagnostics;

    /// <summary>
    /// 
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

            // Add additional logic
        }
    }
}
