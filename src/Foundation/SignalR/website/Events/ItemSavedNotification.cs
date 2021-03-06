using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using RealtimeNotifier.Foundation.SignalR.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.DependencyInjection;
using Sitecore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtimeNotifier.Foundation.SignalR.Events
{
    public class ItemSavedNotification
    {
        protected void OnItemSaved(object sender, EventArgs args)
        {
            Sitecore.Data.Items.Item item = Event.ExtractParameter<Sitecore.Data.Items.Item>(args, 0);
            if (item.Paths.FullPath.ToLowerInvariant().StartsWith("/sitecore/content"))
            {
                var signalService = ServiceLocator.ServiceProvider.GetService(typeof(ISignalRService)) as ISignalRService;
                signalService.Signal(new Notification() { ItemName = item.Name, ItemID = item.ID.Guid.ToString("N"), UserName = item.Statistics.UpdatedBy, ItemPath = item.Paths.FullPath });
            }
        }
    }

    public class Notification :BaseModel
    {
        
    }
}