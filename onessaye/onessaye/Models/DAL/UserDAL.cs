using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;
using onessaye.Models.EXCEPTIONS;

//Bisconti Flavian

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
        public User GetUser(string nickname)
        {
            User user = dbc.DbUser.FirstOrDefault(u => u.Nickname == nickname);
            if (user != null) return user;
            else
            {
                UnableToLogInException ex = new UnableToLogInException("Impossible to log you in", "The nickname entered doesn't exist within the database");
                ex.Data.Add("TimeStamp",String.Format("An error occured at ",DateTime.Now));
                ex.Data.Add("Cause", $"The nickname {nickname} is unknown");
                throw ex;
            }
        }
    }
}