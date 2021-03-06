using System;
using RealtimeNotifier.Feature.WorkBoxActivities.Models;
using RealtimeNotifier.Foundation.SignalR.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Workflows.Simple;

namespace RealtimeNotifier.Feature.WorkBoxActivities.Workflow.Action
{
    public class OnSubmitAction
    {
        public void Process(WorkflowPipelineArgs args)
        {
            Item dataItem = args.DataItem;
            var signalService = ServiceLocator.ServiceProvider.GetService(typeof(ISignalRService)) as ISignalRService;
            if (signalService != null)
                signalService.Signal(
                    new SubmitActivityNotification()
                    {
                        Message = $"submitted the item {dataItem.Paths.FullPath} in Workflow.",
                        UserName = Sitecore.Context.User.Profile.UserName,
                        UserFullName = Sitecore.Context.User.Profile.FullName,
                        NotificationType = NotificationType.WorkflowSaved,
                        DateTime = DateTime.Now.ToString()
                    });
        }
    }
}