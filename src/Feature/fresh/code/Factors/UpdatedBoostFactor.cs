namespace Sitecore.Feature.Indicator.Factors
{
    using System;
    using Data.Fields;
    using Diagnostics;

    /// <summary>
    /// Boost Factor Implementation for Freshness by Updated Date
    /// </summary>
    public class UpdatedBoostFactor : IFactor
    {
        /// <summary>
        /// Gets or sets a value to subtract from the system date 
        /// before comparison against the update date of each item
        /// to determine whether to boost that item due to its freshness.
        /// Defaults to the number of days in the previous month.
        /// </summary>
        public int? MaxDays { get; set; }

        /// <summary>
        /// Maximum value for the boost. Defaults to 5.
        /// </summary>
        public int? MaxBoost { get; set; }

        /// <summary>
        /// Resolves the boost by calculating how fresh the content is 
        /// by the Current Date minus the last updated date
        /// </summary>
        /// <param name="args">The args</param>
        /// <returns><c>Boost</c> value</returns>
        public float Boost(FactorArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            var displayDate = (DateField)args.Item.Fields[FieldIDs.Updated];

            if (displayDate == null)
            {
                return 0;
            }

            if (!this.MaxDays.HasValue)
            {
                this.MaxDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1);
            }

            // Date for comparison
            var when = DateTime.Now.AddDays(-this.MaxDays.Value);

            // Difference between updated date and comparison date
            var difference = displayDate.DateTime - when;

            if (difference.TotalDays <= 0)
            {
                return 0 ;
            }

            if (!this.MaxBoost.HasValue)
            {
                this.MaxBoost = 5;
            }
            
            return ((((float)this.MaxBoost.Value - 1) / this.MaxDays.Value) * (float)difference.TotalDays);
        }
    }
}
