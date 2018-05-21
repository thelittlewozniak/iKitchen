using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;
using onessaye.Models.DAL;

namespace onessaye.Models.DAL
{
    public class RegisterDAL
    {
        private DbConnection dbc;
        private RsaDAL rsa;
        public RegisterDAL()
        {
            dbc = new DbConnection();
            rsa = new RsaDAL();
            rsa.Password = "";
        }
        public void AddUserDb(Neighbor myUser)
        {
            myUser.Password = rsa.Encryption(myUser.Password);
            dbc.DbNeighbor.Add(myUser);
            dbc.SaveChanges();
        }
        public void AddCookDb(Cook myUser)
        {
            myUser.Password = rsa.Encryption(myUser.Password);
            dbc.DbCook.Add(myUser);
            dbc.SaveChanges();
        }
    }
}