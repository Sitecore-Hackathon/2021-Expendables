using System;
using RealtimeNotifier.Feature.WorkBoxActivities.Models;
using RealtimeNotifier.Foundation.SignalR.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Workflows.Simple;

namespace RealtimeNotifier.Feature.WorkBoxActivities.Workflow.Action
{
    public class OnRejectAction
    {
        public void Process(WorkflowPipelineArgs args)
        {
            Item dataItem = args.DataItem;
            var signalService = ServiceLocator.ServiceProvider.GetService(typeof(ISignalRService)) as ISignalRService;
            if (signalService != null)
                signalService.Signal(
                    new PublishActivityNotification()
                    {
                        Message = $"rejected the item {dataItem.Paths.FullPath} which was in workflow.",
                        UserName = Sitecore.Context.User.Profile.UserName,
                        UserFullName = Sitecore.Context.User.Profile.FullName,
                        NotificationType = NotificationType.WorkflowRejected,
                        DateTime = DateTime.Now.ToString()
                    });
        }
    }
}