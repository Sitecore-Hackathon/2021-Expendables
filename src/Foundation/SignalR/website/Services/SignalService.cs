using Microsoft.AspNet.SignalR;
using RealtimeNotifier.Foundation.SignalR.Models;

namespace RealtimeNotifier.Foundation.SignalR.Services
{
    public class SignalService : ISignalRService
    {
        public void Signal(BaseModel tModel)
        {
            var clients = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients;
            clients.All.notify(tModel);
        }

        public void WorkboxSignal(BaseModel tModel)
        {
            var clients = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients;
            clients.All.workboxnotify(tModel);
        }

        public void ItemActivitySignal(BaseModel tModel)
        {
            var clients = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients;
            clients.All.itemActivityNotify(tModel);
        }
    }
}