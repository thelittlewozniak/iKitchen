using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Neighbour:User
    {
        public List<Order> ListOrder { get; set; }
    }
}