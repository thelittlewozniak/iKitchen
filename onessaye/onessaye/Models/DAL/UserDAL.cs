using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;

namespace onessaye.Models.DAL
{
    public class UserDAL
    {
        private DbConnection dbc;
        //Builder
        public UserDAL()
        {
            dbc = new DbConnection();
        }
        //Methods
        public void AddUser(User u)
        {
            dbc.DbUser.Add(u);
            dbc.SaveChanges();
        }
    }
}