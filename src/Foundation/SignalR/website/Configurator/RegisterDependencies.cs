using Microsoft.Extensions.DependencyInjection;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtimeNotifier.Foundation.SignalR.Configurator
{
    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection services)
        {
            services.AddSingleton(typeof(ISignalRService), typeof(SignalService));
        }
    }
}