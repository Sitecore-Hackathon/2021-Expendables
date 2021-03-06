using Owin;
using Sitecore.Owin.Pipelines.Initialize;

namespace RealtimeNotifier.Foundation.SignalR.Pipelines.OwinInitialize
{
    public class InitializeSignalR : Sitecore.Owin.Pipelines.Initialize.InitializeProcessor
    {
        public override void Process(InitializeArgs args)
        {
            args.App.MapSignalR();
        }
    }
}