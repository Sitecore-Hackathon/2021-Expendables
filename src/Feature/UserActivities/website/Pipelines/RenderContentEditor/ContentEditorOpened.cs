using RealtimeNotifier.Feature.UserActivities.Model;
using RealtimeNotifier.Foundation.SignalR.Models;
using RealtimeNotifier.Foundation.SignalR.Services;
using Sitecore.DependencyInjection;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;
using System;
using System.Web;

namespace RealtimeNotifier.Feature.UserActivities.Pipelines.RenderContentEditor
{
    public class ContentEditorOpened
    {
        public void Process(RenderContentEditorArgs args)
        {
            if (HttpContext.Current.Request.Url.ToString().ToLowerInvariant().Contains("/sitecore/shell/applications/workbox/commenteditor.aspx"))
            {
                return;
            }
            var signalService = ServiceLocator.ServiceProvider.GetService(typeof(ISignalRService)) as ISignalRService;
            if (signalService != null)
                signalService.Signal(new UserActivityNotification()
                {
                    Message = $"Opened the content editor.", UserName = Sitecore.Context.User.Profile.UserName,
                    NotificationType = NotificationType.ContentEditorOpened, DateTime = DateTime.Now.ToString()
                });
        }
    }
}