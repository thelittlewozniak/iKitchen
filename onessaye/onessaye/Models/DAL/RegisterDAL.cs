using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;

namespace onessaye.Models.DAL
{
    public class RegisterDAL
    {
        private DbConnection dbc;
        public RegisterDAL()
        {
            this.dbc = new DbConnection();
        }
        public void AddUserDb(User myUser)
        {
            dbc.DbNeighbor.Add(myUser as Neighbor);
            dbc.SaveChanges();
        }
        public void AddCookDb(User myUser)
        {
            dbc.DbCook.Add(myUser as Cook);
            dbc.SaveChanges();
        }
    }
}