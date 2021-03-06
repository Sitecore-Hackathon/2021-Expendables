using RealtimeNotifier.Feature.ItemActivities.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.Diagnostics;
using Sitecore.Events;
using System;

namespace RealtimeNotifier.Feature.ItemActivities.Events
{
    /// <summary>
    /// Class that handle to send push notification when item is saved by the user.
    /// </summary>
    public class ItemSavedNotification
    {
        private ISignalRService signalRService;
        public ItemSavedNotification(ISignalRService signalRService)
        {
            this.signalRService = signalRService;
        }

        protected void OnItemSaved(object sender, EventArgs args)
        {
            try
            {
                //Taking the item from Arguments
                Sitecore.Data.Items.Item item = Event.ExtractParameter<Sitecore.Data.Items.Item>(args, 0);
                if (item.Database.Name.ToLowerInvariant().Equals("web"))
                {
                    return;
                }
                //To avoid double notifications while renaming the item, we put a check on the 'name' property
                //in the Properties list.
                var itemChanges = Event.ExtractParameter<Sitecore.Data.Items.ItemChanges>(args, 1);
                //Boolean created to avoid Item Save Notification when the Item is renamed
                var isRenamed = itemChanges.Properties.ContainsKey("name");
                //When Created and Updated date are same, means the Item got created! Don't fire Save Notification
                if (item.Paths.FullPath.ToLowerInvariant().StartsWith("/sitecore/content") && signalRService != null && item.Statistics.Created != item.Statistics.Updated && !isRenamed)
                {
                    signalRService.ItemActivitySignal(new ItemModel()
                    {
                        ItemName = item.Name,
                        ItemID = item.ID.Guid.ToString("N"),
                        UserName = item.Statistics.UpdatedBy,
                        UserFullName = Sitecore.Context.User.Profile.FullName,
                        ItemPath = item.Paths.FullPath,
                        Message = $"{item.Name} has been updated.",
                        DateTime = DateTime.Now.ToString()
                    });
                    Log.Debug($"ItemSavedNotification.OnItemSaved: Triggered realtime notification for {item.ID}", this);
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
            }
        }
    }
}