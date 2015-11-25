using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSAAklFront.Models
{
    public class Comment
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}