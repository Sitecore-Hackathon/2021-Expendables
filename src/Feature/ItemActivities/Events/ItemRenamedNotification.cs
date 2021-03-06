using System;
using RealtimeNotifier.Feature.ItemActivities.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.Diagnostics;
using Sitecore.Events;

namespace RealtimeNotifier.Feature.ItemActivities.Events
{
    /// <summary>
    /// Class that handle to send push notification when item is saved by the user.
    /// </summary>
    public class ItemRenamedNotification
    {
        private ISignalRService signalRService;
        public ItemRenamedNotification(ISignalRService signalRService)
        {
            this.signalRService = signalRService;
        }

        protected void OnItemRenamed(object sender, EventArgs args)
        {
            try
            {
                //Taking the item from Arguments
                Sitecore.Data.Items.Item item = Event.ExtractParameter<Sitecore.Data.Items.Item>(args, 0);
                if (item.Database.Name.ToLowerInvariant().Equals("web"))
                {
                    return;
                }
                //Make sure items renamed below the "/sitecore/content" node are only considered for the notification.
                if (item.Paths.FullPath.ToLowerInvariant().StartsWith("/sitecore/content") && signalRService != null)
                {
                    signalRService.ItemActivitySignal(new ItemModel()
                    {
                        ItemName = item.Name,
                        ItemID = item.ID.Guid.ToString("N"),
                        UserName = item.Statistics.UpdatedBy,
                        UserFullName = Sitecore.Context.User.Profile.FullName,
                        ItemPath = item.Paths.FullPath,
                        Message = $"{item.Name} has been renamed.",
                        DateTime = DateTime.Now.ToString()
                    });
                    Log.Debug($"ItemSavedNotification.OnItemRenamed: Triggered realtime notification for {item.ID}", this);
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
            }
        }
    }
}