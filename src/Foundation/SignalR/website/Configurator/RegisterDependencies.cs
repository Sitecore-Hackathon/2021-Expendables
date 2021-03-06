using Microsoft.Extensions.DependencyInjection;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.DependencyInjection;

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