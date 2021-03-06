using Owin;
using Sitecore.Owin.Pipelines.Initialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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