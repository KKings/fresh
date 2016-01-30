namespace Sitecore.Feature.Indicator.Pipelines.GetContentEditorWarnings
{
    using System;
    using Data.Items;
    using Diagnostics;
    using Freshness;
    using Services;
    using Sitecore.Pipelines;
    using Sitecore.Pipelines.GetContentEditorWarnings;
    using Sitecore.Pipelines.GetPageEditorNotifications;

    /// <summary>
    /// 
    /// </summary>
    public class NotificationIndicator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Process(GetContentEditorWarningsArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.Item, "args.Item");

            var freshnessArgs = new FreshnessArgs(args.Item);

            CorePipeline.Run(Constants.FreshnessPipeline, freshnessArgs);

            if (freshnessArgs.FreshnessRating.Freshometer == Freshometer.Fresh)
            {
                return;
            }

            var message = freshnessArgs.FreshnessRating.Freshometer == Freshometer.Ew
                ? String.Format(Constants.EwNotificationMessage, args.Item.Name)
                : String.Format(Constants.StaleNotificationMessage, args.Item.Name);

            var warning = args.Add();
            warning.Title = "Freshness Alert";
            warning.Text = message;
        }
    }
}
