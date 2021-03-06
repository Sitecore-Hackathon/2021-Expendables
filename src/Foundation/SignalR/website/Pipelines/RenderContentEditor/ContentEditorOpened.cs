using RealtimeNotifier.Foundation.SignalR.Events;
using RealtimeNotifier.Foundation.SignalR.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.DependencyInjection;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtimeNotifier.Foundation.SignalR.Pipelines.RenderContentEditor
{
    public class ContentEditorOpened
    {
        public void Process(RenderContentEditorArgs args)
        {
            var signalService = ServiceLocator.ServiceProvider.GetService(typeof(ISignalRService)) as ISignalRService;
            signalService.Signal(new UserActivityNotification() { Message = $"Opened the content editor.", UserName = Sitecore.Context.User.Profile.UserName, NotificationType = Models.NotificationType.ContentEditorOpened });
        }
    }
}