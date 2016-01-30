using System.Linq;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Data.DataAccess;

namespace Sitecore.Feature.Indicator.Factors
{
    using System;
    using Data.Fields;
    using Diagnostics;

    using Sitecore.Analytics;
    using Sitecore.Analytics.Data.DataAccess;

    /// <summary>
    /// Boost Factor Implementation for Freshness by Updated Date
    /// </summary>
    public class PageTrafficFactor : IFactor
    {
        /// <summary>
        /// Resolves the boost by calculating how fresh the content is 
        /// by the Current Date minus the last updated date
        /// </summary>
        /// <param name="args">The args</param>
        /// <returns><c>Boost</c> value</returns>
        public float Boost(FactorArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
        }
    }
}
