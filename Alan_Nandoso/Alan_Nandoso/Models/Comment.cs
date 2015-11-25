using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Alan_Nandoso.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}