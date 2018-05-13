using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;

//Bisconti Flavian

namespace onessaye.Views.ViewClasses
{
    public class DisplayUserInformation
    {
        private User user = null;
        public string[] TabLabels = new string[]
        {
            "Nickname", "Last name", "First name", "Gender", "Age", "Email", "Registered since" 
        };
        public DisplayUserInformation(User u)
        {
            user = u;
            BuildTabInfos();
        }
        //Purpose : making the display of the information easier on the cook profile page
        public string[] TabInfos;
        private void BuildTabInfos()
        {
            string date = String.Format("{0:G}", user.DateRegister);
            TabInfos = new string[]
            {
                user.Nickname, user.LastName, user.FirstName, user.Gender, Convert.ToString(user.Age), 
                user.Email, date
            };
        }
    }
}