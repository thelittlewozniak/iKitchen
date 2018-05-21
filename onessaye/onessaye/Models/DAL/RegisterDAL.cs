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
            dbc = new DbConnection();
        }
        public void AddUserDb(Neighbor myUser)
        {
            dbc.DbNeighbor.Add(myUser);
            dbc.SaveChanges();
        }
        public void AddCookDb(Cook myUser)
        {
            dbc.DbCook.Add(myUser);
            dbc.SaveChanges();
        }
    }
}