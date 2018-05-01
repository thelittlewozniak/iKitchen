using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Comment
    {
        public virtual User User { get; set; }
        public float Rating { get; set; }
        public DateTime DatePost { get; set; }
        public string Content { get; set; }
    }
}