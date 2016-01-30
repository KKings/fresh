namespace Sitecore.Feature.Indicator.Pipelines.GetPageEditorNotifications
{
    using Data.Items;
    using Sitecore.Pipelines.GetPageEditorNotifications;

    /// <summary>
    /// 
    /// </summary>
    public class NotificationIndicator : GetPageEditorNotificationsProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void Process(GetPageEditorNotificationsArgs args)
        {
            
        }

        /// <summary>
        /// Add a warning option to the GetPageEditorNotificationsArgs
        /// </summary>
        /// <param name="dataSourceItem">Item to reference</param>
        /// <param name="pageEditorNotification">Page Editor Notification</param>s
        private void AddWarningOption(Item dataSourceItem, PageEditorNotification pageEditorNotification)
        {
            pageEditorNotification.Options.Add(new PageEditorNotificationOption(dataSourceItem.Name,
                $"webedit:open(id={dataSourceItem.ID},language={dataSourceItem.Language},version={dataSourceItem.Version.Number})"));
        }
    }
}
