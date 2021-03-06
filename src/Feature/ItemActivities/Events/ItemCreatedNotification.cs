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
    public class ItemCreatedNotification
    {
        private ISignalRService signalRService;
        public ItemCreatedNotification(ISignalRService signalRService)
        {
            this.signalRService = signalRService;
        }

        protected void OnItemSaved(object sender, EventArgs args)
        {
            Sitecore.Data.Items.Item item = Event.ExtractParameter<Sitecore.Data.Items.Item>(args, 0);
            var itemChanges = Event.ExtractParameter<Sitecore.Data.Items.ItemChanges>(args, 1);
            var hasWorkFlowField = itemChanges.FieldChanges.Cast<FieldChange>().Any(f => f.FieldID == Sitecore.FieldIDs.Workflow);
            if (item.Paths.FullPath.ToLowerInvariant().StartsWith("/sitecore/content") && signalRService != null && item.Statistics.Created == item.Statistics.Updated && !hasWorkFlowField)
            {
                signalRService.ItemActivitySignal(new ItemModel()
                {
                    ItemName = item.Name,
                    ItemID = item.ID.Guid.ToString("N"),
                    UserName = item.Statistics.UpdatedBy,
                    UserFullName = Sitecore.Context.User.Profile.FullName,
                    ItemPath = item.Paths.FullPath,
                    Message = $"{item.Name} has been created.",
                    DateTime = DateTime.Now.ToString()
                });
                Log.Info($"ItemCreatedNotification.OnItemSaved: Triggered realtime notification for {item.ID}", this);
            }
        }
    }
}