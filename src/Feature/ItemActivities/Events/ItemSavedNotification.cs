using RealtimeNotifier.Feature.ItemActivities.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            Sitecore.Data.Items.Item item = Event.ExtractParameter<Sitecore.Data.Items.Item>(args, 0);
            //To avoid double notifications while renaming the item, we put a check on the 'name' property
            //in the Properties list.
            var itemChanges = Event.ExtractParameter<Sitecore.Data.Items.ItemChanges>(args, 1);
            var isRenamed = itemChanges.Properties.ContainsKey("name");
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
                Log.Info($"ItemSavedNotification.OnItemSaved: Triggered realtime notification for {item.ID}", this);
            }
        }
    }
}