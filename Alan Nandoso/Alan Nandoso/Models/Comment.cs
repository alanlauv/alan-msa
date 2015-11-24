using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alan_Nandoso.Model
{
    public class Comment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public virtual Reply Reply { get; set; }
    }
}