using RealtimeNotifier.Feature.ItemActivities.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using System.Linq;
using System;

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
            try
            {
                //Taking the item from Arguments
                Item item = Event.ExtractParameter<Item>(args, 0);
                if (item.Database.Name.ToLowerInvariant().Equals("web"))
                {
                    return;
                }
                var itemChanges = Event.ExtractParameter<ItemChanges>(args, 1);
                //Boolean created to avoid Item Save Notification when the Item is Created and Workflow is assigned while creation
                var hasWorkFlowField = itemChanges.FieldChanges.Cast<FieldChange>().Any(f => f.FieldID == Sitecore.FieldIDs.Workflow);
                //When Created and Updated date are same, means the Item got created!
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
                    Log.Debug($"ItemCreatedNotification.OnItemSaved: Triggered realtime notification for {item.ID}", this);
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
            }
        }
    }
}