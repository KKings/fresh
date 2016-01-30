namespace Sitecore.Feature.Freshness.Factors
{
    using Data.Items;

    /// <summary>
    /// Factor implementation for resolving a factor
    /// </summary>
    public interface IFactor
    {
        /// <summary>
        /// Gets or sets the Factor Weight
        /// </summary>
        int MaxValue { get; set; }

        /// <summary>
        /// Resolves the boost for the factor
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns><c>Float</c> indicating the boost fro the factor</returns>
        decimal Score(Item item);
    }
}
