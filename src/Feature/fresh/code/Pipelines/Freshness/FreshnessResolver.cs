namespace Sitecore.Feature.Freshness.Pipelines.Freshness
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Diagnostics;
    using Factors;
    using Services;

    public class FreshnessResolver
    {
        /// <summary>
        /// Freshness Service for calculating the freshness boost
        /// </summary>
        private readonly IFreshnessService _freshnessService;

        /// <summary>
        /// Gets or sets the Factors
        /// </summary>
        public IList<IFactor> Factors { get; set; } = new List<IFactor>();

        public FreshnessResolver()
        {
            _freshnessService = new FreshnessService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Process(FreshnessArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.Item, "args.Item");

            args.FreshnessRating = this._freshnessService.Resolve(args.Item, this.Factors);
        }

        /// <summary>
        /// Adds an IFactor into the Factors from the configuration
        /// </summary>
        /// <param name="node">Configured Node</param>
        private void Add(XmlNode node)
        {
            this.Factors.Add(Configuration.Factory.CreateObject<IFactor>(node));
        }
    }
}
