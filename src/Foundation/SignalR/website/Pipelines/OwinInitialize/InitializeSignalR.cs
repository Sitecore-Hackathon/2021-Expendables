using Owin;
using Sitecore.Owin.Pipelines.Initialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtimeNotifier.Foundation.SignalR.Pipelines.OwinInitialize
{
    /// <summary>
    /// The <see cref="InitializeSignalR"/> processor binds the SignalR to the IAppBuilder.
    /// </summary>
    public class InitializeSignalR : Sitecore.Owin.Pipelines.Initialize.InitializeProcessor
    {
        public override void Process(InitializeArgs args)
        {
            args.App.MapSignalR();
        }
    }
}