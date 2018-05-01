using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Order
    {
        public DateTime CreationDate { get; set; }
        public DateTime ReceiptDate { get; set; }
        public Recipe Recipe { get; set; }
        public string State { get; set; }
    }
}