using RealtimeNotifier.Feature.ItemActivities.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.Publishing.Pipelines.Publish;
using System;

namespace RealtimeNotifier.Feature.ItemActivities.Pipelines
{
    public class CustomPublishProcessor : PublishProcessor
    {
        private ISignalRService signalRService;

        public CustomPublishProcessor()
        {
            this.signalRService = ServiceLocator.ServiceProvider.GetService(typeof(ISignalRService)) as ISignalRService;
        }

        public CustomPublishProcessor(ISignalRService signalRService)
        {
            this.signalRService = signalRService;
        }

        public override void Process(PublishContext context)
        {
            try
            {
                signalRService.ItemActivitySignal(new ItemModel()
                {
                    ItemName = string.Empty,
                    ItemID = string.Empty,
                    UserName = Sitecore.Context.User.Profile.UserName,
                    UserFullName = Sitecore.Context.User.Profile.FullName,
                    ItemPath = string.Empty,
                    Message = $"Publishing has been done.",
                    DateTime = DateTime.Now.ToString()
                });
                Log.Debug($"CustomPublishProcessor.Process: Triggered realtime notification for publishing.", this);
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
            }
        }
    }
}