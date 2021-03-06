using Newtonsoft.Json;
using System;

namespace RealtimeNotifier.Foundation.SignalR.Models
{
    /// <summary>
    /// The <see cref="BaseModel"/> class which provide all necessary properties to be used for 
    /// creating the notification data model.
    /// </summary>
    public class BaseModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("userDisplayName")]
        public String UserDisplayName { get; set; }

        [JsonProperty("userFullName")]
        public String UserFullName { get; set; }

        [JsonProperty("userEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("itemID")]
        public string ItemID { get; set; }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("itemPath")]
        public string ItemPath { get; set; }

        [JsonProperty("notificationType")]
        public NotificationType NotificationType { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("time")]
        public string DateTime { get; set; }
    }

    public enum NotificationType
    {
        ItemSaved,
        ItemSaving,
        UserLogged,
        UserLoggerOut,
        ContentEditorOpened,
        WorkflowSaved,
        WorkflowApproved,
        WorkflowRejected
    }
}