using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;
using onessaye.Models.DAL;

//Bisconti Flavian

namespace onessaye.Views.ViewClasses
{
    public class DisplayUserInformation
    {
        public User User { get; set; }
        public string[] TabLabels = new string[]
        {
            "Nickname", "Last name", "First name", "Gender", "Age", "Email", "Registered since" 
        };
        public DisplayUserInformation(Cook user)
        {
            User = user;
            BuildTabInfos();
        }
        public DisplayUserInformation(Neighbor user)
        {
            User = user;
            BuildTabInfos();
        }
        //Purpose : making the display of the information easier on the cook profile page
        public string[] TabInfos;
        private void BuildTabInfos()
        {
            string date = String.Format("{0:G}", User.DateRegister);
            TabInfos = new string[]
            {
                User.Nickname, User.LastName, User.FirstName, User.Gender, Convert.ToString(User.Age), 
                User.Email, date
            };
        }
    }
}