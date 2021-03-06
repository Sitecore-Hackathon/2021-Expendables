using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;
using Sitecore.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace RealtimeNotifier.Foundation.SignalR.Pipelines.RenderContentEditor
{
    public class RegisterSignalRScripts
    {
        private const string JavascriptTag = "<script src=\"{0}\"></script>";

        protected IList<string> Scripts { get; } = new List<string>();

        public void AddScriptResource(string resource) => this.Scripts.Add(resource);

        public void Process(RenderContentEditorArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));
            if(!(HttpContext.Current.Handler is Page handler))
            {
                return;
            }
            foreach(string script in this.Scripts)
            {
                handler.Header.Controls.Add((Control)new LiteralControl(JavascriptTag.FormatWith(script)));
            }
        }
    }
}