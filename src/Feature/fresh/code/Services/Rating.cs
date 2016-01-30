namespace Sitecore.Feature.Freshness.Services
{
    public class FreshnessRating
    {
        /// <summary>
        /// Gets or sets the Freshometer
        /// </summary>
        public Freshometer Freshometer { get; set; }

        /// <summary>
        /// Freshness Score
        /// </summary>
        public decimal Score { get; set; }
    }
}

