using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Neighbor:User
    {
        public List<Order> ListOrder { get; set; }
        public Neighbor()
        {
            ListOrder = new List<Order>();
        }
        public void AddOrder(Order newOrder) => ListOrder.Add(newOrder);
    }
}