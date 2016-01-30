namespace Sitecore.Feature.Indicator.Gutters
{
    using System;
    using Configuration;
    using Data.Items;
    using Pipelines.Freshness;
    using Services;
    using Shell.Applications.ContentEditor.Gutters;
    using Sitecore.Pipelines;

    /// <summary>
    /// Generates the Freshness Gutter  Icon
    /// </summary>
    public class GutterIndicator : GutterRenderer
    {
        /// <summary>
        /// Freshy Fresh Icon
        /// </summary>
        private const string FreshIcon = "Applications/32x32/bullet_ball_green.png";

        /// <summary>
        /// Staley Stale Icon
        /// </summary>
        private const string StaleIcon = "Applications/32x32/bullet_ball_yellow.png";

        /// <summary>
        /// OMG EW! Icon
        /// </summary>
        private const string EwIcon = "Applications/32x32/bullet_ball_red.png";

        /// <summary>
        /// Tooltip for OMG Ew!
        /// </summary>
        private const string EwToolTip = "{0} is out of date.";

        /// <summary>
        /// Tooltip for Stale
        /// </summary>
        private const string StaleToolTip = "{0} is going out of date.";

        /// <summary>
        /// Tooltip for Freshy Fresh
        /// </summary>
        private const string FreshToolTip = "{0} is freshy fresh!!";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override GutterIconDescriptor GetIconDescriptor(Item item)
        {
            if (String.IsNullOrEmpty(item[FieldIDs.LayoutField]))
            {
                return null;
            }

            var iconPath = String.Empty;
            var iconTooltip = String.Empty;

            var freshnessArgs = new FreshnessArgs(item);

            CorePipeline.Run(Constants.FreshnessPipeline, freshnessArgs);

            switch (freshnessArgs.FreshnessRating.Freshometer)
            {
                case Freshometer.Fresh:
                {
                    iconPath = GutterIndicator.FreshIcon;
                    iconTooltip = String.Format(GutterIndicator.FreshToolTip, item.Name);
                    break;
                }
                case Freshometer.Stale:
                {
                    iconPath = GutterIndicator.StaleIcon;
                    iconTooltip = String.Format(GutterIndicator.StaleToolTip, item.Name);
                    break;
                }
                default:
                {
                    iconPath = GutterIndicator.EwIcon;
                    iconTooltip = String.Format(GutterIndicator.EwToolTip, item.Name);
                    break;
                }
            }

            var gutterIconDescriptor = new GutterIconDescriptor
            {
                Icon = iconPath,
                Tooltip = iconTooltip,
                Click = $"item:setlayoutdetails(id={item.ID})"
            };

            return gutterIconDescriptor;
        }
    }
}
