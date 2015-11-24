using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alan_Nandoso.Models
{
    public class Reply
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public int CommentID { get; set; }

        [JsonIgnore]
        public virtual Comment Comment { get; set; }
    }
}