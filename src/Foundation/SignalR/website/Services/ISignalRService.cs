using Microsoft.AspNet.SignalR.Hubs;
using RealtimeNotifier.Foundation.SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeNotifier.Foundation.SignalR.Services
{
    public interface ISignalRService
    {
        void Signal(BaseModel tModel);
    }
}
