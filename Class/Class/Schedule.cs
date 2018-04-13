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
        public List<DateTime> GetAvailableDate => listAvailableDate;
        public List<Order> GetOrders => listDateOrders;
        public Schedule Instance
        {
            get
            {
                if (instance == null)
                {
                    instance=new Schedule(null, null);
                }
                return instance;
            }
        }
        private Schedule(List<DateTime> listAvailanleDate,List<Order> listDateOrders)
        {
            this.listAvailableDate = listAvailanleDate;
            this.listDateOrders = listDateOrders;
        }
        public void AddAvailableDate(DateTime date) => listAvailableDate.Add(date);
        public void AddOrders(Order order) => listDateOrders.Add(order);
        public void DeleteOrders(Order order) => listDateOrders.Remove(order);
    }
}
