﻿using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor.Pipelines.RenderContentEditor;
using Sitecore.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace RealtimeNotifier.Foundation.SignalR.Pipelines.RenderContentEditor
{
    public class RegisterSignalRResources
    {
        private const string JavascriptTag = "<script src=\"{0}\"></script>";
        private const string LinkTag = "<link rel=\"stylesheet\" href=\"{0}\" />";

        protected IList<string> Scripts { get; } = new List<string>();

        protected IList<string> Styles { get; } = new List<string>();

        public void AddScriptResource(string resource) => this.Scripts.Add(resource);

        public void AddStyleResource(string resource) => this.Styles.Add(resource);

        public void Process(RenderContentEditorArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));
            if(!(HttpContext.Current.Handler is Page handler))
            {
                return;
            }
            //Add the current logged in user details
            try
            {
                var serializationSettings = new Newtonsoft.Json.JsonSerializerSettings();
                serializationSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                serializationSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                
                handler.Header.Controls.Add((Control)new LiteralControl(String.Format("<script>window.scUser = {0}</script>", Newtonsoft.Json.JsonConvert.SerializeObject(new { 
                    UserName = Sitecore.Context.User.Profile.UserName,
                    DisplayName = Sitecore.Context.User.DisplayName,
                    FullName = Sitecore.Context.User.Profile.FullName,
                    Email = Sitecore.Context.User.Profile.Email,
                    IsAdministartor = Sitecore.Context.User.IsAdministrator
                }, serializationSettings))));
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error($"{this} {ex.Message}", ex, this);
            }
            foreach(string script in this.Scripts)
            {
                handler.Header.Controls.Add((Control)new LiteralControl(JavascriptTag.FormatWith(script)));
            }
            foreach (string style in this.Styles)
            {
                handler.Header.Controls.Add((Control)new LiteralControl(LinkTag.FormatWith(style)));
            }
        }
    }
}