using System;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Pipelines;
using Sitecore.Pipelines.Logout;
using Sitecore.Resources;
using Sitecore.Security.Accounts;
using Sitecore.Shell.Applications;
using Sitecore.Web;
using Sitecore.Web.UI;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;
using Literal = Sitecore.Web.UI.HtmlControls.Literal;

namespace RealtimeNotifier.Feature.WorkBoxActivities.sitecore.shell.Applications
{
    public class CustomGlobalHeader : GlobalHeader
    {
        // Fields
        protected Literal globalHeaderUserName;
        protected ThemedImage globalHeaderUserPortrait;
        protected HtmlAnchor globalLogo;
        protected PlaceHolder placeHolder;
        protected Literal globalUserRoles;
        // Methods

        protected new void Page_Load(object sender, EventArgs e)
        {
            if (WebUtil.GetQueryString(State.Client.UsesBrowserWindowsQueryParameterName) == "1")
            {
                this.placeHolder.Visible = true;
                User user = Sitecore.Context.User;
                this.globalHeaderUserName.Text = HttpUtility.HtmlEncode(string.IsNullOrEmpty(user.Profile.FullName) ? user.LocalName : user.Profile.FullName);
                this.globalHeaderUserPortrait.Src = Images.GetThemedImageSource(user.Profile.Portrait, ImageDimension.id32x32);
                Item item = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse("{6B846FBD-8549-4C91-AE6B-18286EFE82D2}"));
                this.globalLogo.HRef = (item != null) ? LinkManager.GetItemUrl(item) : "#";
                var roleList = user.Roles.ToList();
                if (roleList.Any())
                {
                    var roleListString = string.Empty;
                    foreach (var role in roleList)
                    {
                        string.Concat(roleListString, "|");
                    }

                    this.globalUserRoles.Text = roleListString;
                }
                else
                {
                    this.globalUserRoles.Text = "No Role Assigned";
                }
            }
        }
    }
}