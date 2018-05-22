using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;

namespace onessaye.Models.DAL
{
    public class OrderDAL : DbContext
    {
        private DbConnection dbc;
        //Builder
        public OrderDAL()
        {
            dbc = new DbConnection();
        }
        public Order GetOrderById(int id)
        {
            return dbc.DbOrder.Include(r => r.Recipe).SingleOrDefault(r => r.Id == id);
        }
        public List<Order> GetOrderByUser(int id)
        {
            List<Neighbor> neighbors = dbc.DbNeighbor.Include(r => r.ListOrder).ToList();
            Neighbor neighbor = (Neighbor)(from neig in neighbors where neig.Id == id select neig);
            List<Order> orders = neighbor.ListOrder;
            return orders;
        }
    }
}