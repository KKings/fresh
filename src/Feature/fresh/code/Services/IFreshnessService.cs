namespace Sitecore.Feature.Freshness.Services
{
    using System.Collections.Generic;
    using Data.Items;
    using Factors;

    public interface IFreshnessService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="factors"></param>
        /// <returns></returns>
        FreshnessRating Resolve(Item item, IList<IFactor> factors);
    }
}
