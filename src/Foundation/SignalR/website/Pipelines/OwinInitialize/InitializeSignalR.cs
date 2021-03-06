using Owin;
using Sitecore.Owin.Pipelines.Initialize;

namespace RealtimeNotifier.Foundation.SignalR.Pipelines.OwinInitialize
{
    /// <summary>
    /// The <see cref="InitializeSignalR"/> processor binds the SignalR to the IAppBuilder.
    /// </summary>
    public class InitializeSignalR : Sitecore.Owin.Pipelines.Initialize.InitializeProcessor
    {
        public override void Process(InitializeArgs args)
        {
            try
            {
                args.App.MapSignalR();
            }
            catch (System.Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
            }
        }
    }
}