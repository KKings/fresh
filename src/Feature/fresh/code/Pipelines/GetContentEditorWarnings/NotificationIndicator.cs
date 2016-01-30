namespace Sitecore.Feature.Indicator.Pipelines.GetContentEditorWarnings
{
    using System;
    using Data.Items;
    using Sitecore.Pipelines.GetContentEditorWarnings;

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
            
        }

        /// <summary>
        /// Add a warning option to the GetContentEditorWarningsArgs
        /// </summary>
        /// <param name="dataSourceItem">Item to reference</param>
        /// <param name="warnings">Content Editor Warnings</param>
        private void AddWarningOption(Item dataSourceItem, GetContentEditorWarningsArgs.ContentEditorWarning warnings)
        {
            warnings.AddOption(dataSourceItem.Name,
                $"item:load(id={dataSourceItem.ID},language={dataSourceItem.Language},version={dataSourceItem.Version.Number})");
        }
    }
}
