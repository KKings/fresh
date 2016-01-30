namespace Sitecore.Feature.Indicator.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Items;
    using Factors;

    public class FreshnessService : IFreshnessService
    {
        /// <summary>
        /// Reslves the Freshness
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="factors">Configured Factors</param>
        /// <returns>Resolved freshness</returns>
        public FreshnessRating Resolve(Item item, IList<IFactor> factors)
        {
            var score = (factors.Select(m => m.Score(item)).Sum()/factors.Count);

            Freshometer freshness;

            if (score < 33)
            {
                freshness = Freshometer.Ew;
            }
            else if (score < 66 && score >= 33)
            {
                freshness = Freshometer.Stale;
            }
            else
            {
                freshness = Freshometer.Fresh;
            }

            return new FreshnessRating
            {
                Score = (factors.Select(m => m.Score(item)).Sum()/factors.Count),
                Freshometer = freshness
            };
        }
    }
}
