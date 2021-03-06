using RealtimeNotifier.Foundation.SignalR.Models;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;
using Sitecore.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace RealtimeNotifier.Foundation.SignalR.Pipelines.RenderContentEditor
{
    /// <summary>
    /// Registers the necessary JavaScript and Stylesheets for the module to work.
    /// </summary>
    public class RegisterSignalRResources
    {
        private const string JavascriptTag = "<script src=\"{0}\"></script>";
        private const string LinkTag = "<link rel=\"stylesheet\" href=\"{0}\" />";

        protected IList<Resource> Scripts { get; } = new List<Resource>();

        protected IList<string> Styles { get; } = new List<string>();

        /// <summary>
        /// Reads the path and order property of the script node from the configuration file.
        /// </summary>
        /// <param name="configNode"></param>
        public void AddScriptResource(XmlNode configNode)
        {
            if (configNode.Attributes == null)
                return;
            if(configNode.Attributes["path"] != null && configNode.Attributes["order"] != null)
            {
                var resource = new Resource()
                {
                    Path = configNode.Attributes["path"].Value,
                    Order = int.Parse(configNode.Attributes["order"].Value)
                };
                this.Scripts.Add(resource);
            }            
        }

        public void AddStyleResource(string resource) => this.Styles.Add(resource);

        public void Process(RenderContentEditorArgs args)
        {
            try
            {
                Assert.ArgumentNotNull(args, nameof(args));
                //We faced the issue of jQuery not getting loaded while submitting the item to workflow and hence
                //we have to apply following fix to avoid the JavaScript related errors.
                if (HttpContext.Current.Request.Url.ToString().ToLowerInvariant().Contains("/sitecore/shell/applications/workbox/commenteditor.aspx"))
                {
                    return;
                }
                if (!(HttpContext.Current.Handler is Page handler))
                {
                    return;
                }
                //Create the JavaScript variable to store the authenticated user information
                //which will be used across module from the client side scripts.
                try
                {
                    var serializationSettings = new Newtonsoft.Json.JsonSerializerSettings();
                    serializationSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializationSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                    handler.Header.Controls.Add((Control)new LiteralControl(String.Format("<script>window.scUser = {0}</script>", Newtonsoft.Json.JsonConvert.SerializeObject(new
                    {
                        UserName = Sitecore.Context.User.Profile.UserName,
                        DisplayName = Sitecore.Context.User.DisplayName,
                        FullName = Sitecore.Context.User.Profile.FullName,
                        Email = Sitecore.Context.User.Profile.Email,
                        IsAdministartor = Sitecore.Context.User.IsAdministrator,
                        Roles = Sitecore.Context.User.Roles
                    }, serializationSettings))));
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
                }

                foreach (Resource resource in this.Scripts.OrderBy(r => r.Order))
                {
                    handler.Header.Controls.Add((Control)new LiteralControl(JavascriptTag.FormatWith(resource.Path)));
                }

                foreach (string style in this.Styles)
                {
                    handler.Header.Controls.Add((Control)new LiteralControl(LinkTag.FormatWith(style)));
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
            }
        }
    }
}