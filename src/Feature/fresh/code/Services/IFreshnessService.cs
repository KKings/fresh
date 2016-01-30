namespace Sitecore.Feature.Indicator.Services
{
    using System.Collections.Generic;
    using Factors;

    public interface IFreshnessService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="factors"></param>
        /// <returns></returns>
        float Resolve(IList<IFactor> factors);
    }
}
