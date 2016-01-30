namespace Sitecore.Feature.Freshness.Pipelines.GetPageEditorNotifications
{
    using System;
    using Diagnostics;
    using Freshness;
    using Services;
    using Sitecore.Pipelines;
    using Sitecore.Pipelines.GetPageEditorNotifications;

    /// <summary>
    /// Adds an experience editor alert if the content is stale or ew
    /// </summary>
    public class NotificationIndicator : GetPageEditorNotificationsProcessor
    {
        /// <summary>
        /// Runs the Freshness Pipeline to determine the freshness
        /// </summary>
        /// <param name="args">The args</param>
        public override void Process(GetPageEditorNotificationsArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.ContextItem, "args.ContextItem");

            var freshnessArgs = new FreshnessArgs(args.ContextItem);

            CorePipeline.Run(Constants.FreshnessPipeline, freshnessArgs);

            if (freshnessArgs.FreshnessRating.Freshometer == Freshometer.Fresh)
            {
                return;
            }

            var message = freshnessArgs.FreshnessRating.Freshometer == Freshometer.Ew
                ? String.Format(Constants.EwNotificationMessage, args.ContextItem.Name)
                : String.Format(Constants.StaleNotificationMessage, args.ContextItem.Name);

            var editorNotification = new PageEditorNotification(Globalization.Translate.Text(message),
                PageEditorNotificationType.Warning);

            args.Notifications.Add(editorNotification);
        }
    }
}
