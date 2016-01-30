namespace Sitecore.Feature.Freshness.Pipelines.GetContentEditorWarnings
{
    using System;
    using Data.Items;
    using Diagnostics;
    using Freshness;
    using Services;
    using Sitecore.Pipelines;
    using Sitecore.Pipelines.GetContentEditorWarnings;

    /// <summary>
    /// Adds a content editor notification for freshness
    /// </summary>
    public class NotificationIndicator
    {
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
            warning.Title = Globalization.Translate.Text("Freshness Alert");
            warning.Text = message;
        }
    }
}
