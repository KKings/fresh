namespace Sitecore.Feature.Freshness.Factors
{
    using System;
    using Data.Fields;
    using Data.Items;
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
        public int MaxDays { get; set; }

        /// <summary>
        /// Gets or sets the Max value
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// Resolves the boost by calculating how fresh the content is 
        /// by the Current Date minus the last updated date
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns><c>Boost</c> value</returns>
        public decimal Score(Item item)
        {
            Assert.ArgumentNotNull(item, "item");

            var displayDate = (DateField)item.Fields[FieldIDs.Updated];

            if (displayDate == null)
            {
                return 0;
            }

            if (this.MaxDays == Int32.MinValue || this.MaxDays == 0)
            {
                this.MaxDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1);
            }

            // Date for comparison
            var when = DateTime.Now.AddDays(-this.MaxDays);

            // Difference between updated date and comparison date
            var difference = displayDate.DateTime - when;

            if (difference.TotalDays <= 0)
            {
                return 0 ;
            }
            
            return ((decimal)this.MaxValue - 1) / this.MaxDays * (decimal)difference.TotalDays;
        }
    }
}
