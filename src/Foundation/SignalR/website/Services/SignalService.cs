using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using RealtimeNotifier.Foundation.SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtimeNotifier.Foundation.SignalR.Services
{
    public class SignalService : ISignalRService
    {
        public void Signal<THub>(BaseModel tModel) where THub : IHub
        {
            var clients = GlobalHost.ConnectionManager.GetHubContext<THub>().Clients;
            clients.All.notify(tModel);
        }
    }
}