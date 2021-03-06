using RealtimeNotifier.Foundation.SignalR.Models;

namespace RealtimeNotifier.Foundation.SignalR.Services
{
    public interface ISignalRService
    {
        void Signal(BaseModel tModel);
        void WorkboxSignal(BaseModel tModel);
        void ItemActivitySignal(BaseModel tModel);
    }
}
