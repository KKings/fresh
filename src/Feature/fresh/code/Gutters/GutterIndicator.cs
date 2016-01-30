namespace Sitecore.Feature.Indicator.Gutters
{
    using System;
    using Configuration;
    using Data.Items;
    using Shell.Applications.ContentEditor.Gutters;

    /// <summary>
    /// 
    /// </summary>
    public class GutterIndicator : GutterRenderer
    {
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

            var iconPath = Settings.GetSetting("PageGutter.Icon");

            if (String.IsNullOrEmpty(iconPath))
            {
                iconPath = "People/32x32/monitor2.png";
            }

            var iconTooltip = Settings.GetSetting("PageGutter.Tooltip");

            if (String.IsNullOrEmpty(iconTooltip))
            {
                iconTooltip = "The item is a page.";
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
