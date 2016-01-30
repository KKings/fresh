
namespace Sitecore.Feature.Indicator.Pipelines.Freshness
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Services;
    using Sitecore.Pipelines;

    public class FreshnessResolver
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IFreshnessService _freshnessService;

        public FreshnessResolver()
        {
            this._freshnessService = new FreshnessService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Process(PipelineArgs args)
        {
            
        }
    }
}
