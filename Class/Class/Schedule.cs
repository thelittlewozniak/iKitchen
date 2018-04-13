using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Schedule
    {
        private static Schedule instance;
        List<DateTime> listAvailableDate;
        List<Order> listDateOrders;
        public List<DateTime> GetSetListDateAvailable { get=>listAvailableDate; set=>listAvailableDate=value; }
        public List<Order> GetSetListOrder { get=>listDateOrders; set=>listDateOrders=value; }
        public Schedule Instance
        {
            get
            {
                if (instance == null)
                {
                    instance=new Schedule();
                }
                return instance;
            }
        }
        private Schedule()
        {
        }
        public void AddAvailableDate(DateTime date) => listAvailableDate.Add(date);
        public void AddOrders(Order order) => listDateOrders.Add(order);
        public void DeleteOrders(Order order) => listDateOrders.Remove(order);
    }
}
