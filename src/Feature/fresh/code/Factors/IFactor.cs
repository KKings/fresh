
namespace Sitecore.Feature.Indicator.Factors
{
    /// <summary>
    /// Factor implementation for resolving a factor
    /// </summary>
    public interface IFactor
    {
        /// <summary>
        /// Resolves the boost for the factor
        /// </summary>
        /// <param name="args">The args</param>
        /// <returns><c>Float</c> indicating the boost fro the factor</returns>
        float Boost(FactorArgs args);
    }
}
