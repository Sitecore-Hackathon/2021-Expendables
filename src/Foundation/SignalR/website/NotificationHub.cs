using Microsoft.AspNet.SignalR;
using RealtimeNotifier.Foundation.SignalR.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtimeNotifier.Foundation.SignalR
{
    public class NotificationHub : Hub
    {
        public void Notify(Notification notification)
        {
            Clients.All.notify(notification);
        }
    }
}