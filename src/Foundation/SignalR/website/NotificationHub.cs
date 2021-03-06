﻿using Microsoft.AspNet.SignalR;
using RealtimeNotifier.Foundation.SignalR.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtimeNotifier.Foundation.SignalR
{
    public class NotificationHub : Hub
    {
        public void Send(Notification notification)
        {
            notification.DateTime = DateTime.Now.ToString();
            Clients.All.notify(notification);
        }
    }
}