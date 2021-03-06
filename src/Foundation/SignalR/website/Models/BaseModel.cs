using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtimeNotifier.Foundation.SignalR.Models
{
    public class BaseModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("itemID")]
        public string ItemID { get; set; }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("itemPath")]
        public string ItemPath { get; set; }
    }
}