using Sitecore.Data.Fields;
using Sitecore.Layouts;
using Sitecore.Shell.Applications.ContentEditor.Gutters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace RealtimeNotifier.Feature.Gutter
{
    public class NotificationGutter : GutterRenderer
    {
        protected override GutterIconDescriptor GetIconDescriptor(Item item)
        {
            if (item != null)
            {
                if (item.Name.Contains("notify") || item["Title"].Contains("notify"))
                {
                    GutterIconDescriptor gutterIconDescriptor = new GutterIconDescriptor
                    {
                        Icon = "Applications/32x32/window_colors.png",
                        Tooltip = "Item recently edited."
                    };

                    if (item.Access.CanWrite() && !item.Appearance.ReadOnly)
                    {
                        gutterIconDescriptor.Click = string.Format("item:setlayoutdetails(id={0})", item.ID);
                    }
                    return gutterIconDescriptor;
                }
            }

            return null;
        }
    }
}