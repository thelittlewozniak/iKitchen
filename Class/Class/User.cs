using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public abstract class User
    {
        private string username;
        private Catalog catalog;
        private Schedule schedule;
        public string GetUsername => username;
        public Catalog GetCatalog =>catalog;
        public Schedule GetSchedule => schedule;
        public User(string username,Catalog catalog,Schedule schedule)
        {
            this.username = username;
            this.catalog = catalog;
            this.schedule = schedule;
        }
        public void DeleteOrder(Order order) => schedule.DeleteOrders(order);
        public string GetEmail => "test@gmail.com";
    }
}
