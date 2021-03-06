using System;
using RealtimeNotifier.Feature.WorkBoxActivities.Models;
using RealtimeNotifier.Foundation.SignalR.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Workflows.Simple;

namespace RealtimeNotifier.Feature.WorkBoxActivities.Workflow.Action
{
    public class OnPublishAction
    {
        public void Process(WorkflowPipelineArgs args)
        {
            try
            {
                Item dataItem = args.DataItem;
                var signalService = ServiceLocator.ServiceProvider.GetService(typeof(ISignalRService)) as ISignalRService;
                if (signalService != null)
                    signalService.WorkboxSignal(
                        new PublishActivityNotification()
                        {
                            Message = $"Approved the item {dataItem.Name} which was in workflow.",
                            UserName = Sitecore.Context.User.Profile.UserName,
                            UserFullName = Sitecore.Context.User.Profile.FullName,
                            NotificationType = NotificationType.WorkflowApproved,
                            DateTime = DateTime.Now.ToString()
                        });
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
            }
        }
    }
}