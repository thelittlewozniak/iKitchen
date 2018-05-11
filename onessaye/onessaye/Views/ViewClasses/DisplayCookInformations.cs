using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;

//Bisconti Flavian

namespace onessaye.Views.ViewClasses
{
    public class DisplayCookInformations
    {
        private Cook c = null;
        public string[] TabLabels = new string[]
        {
            "Nickname", "Last name", "First name", "Gender", "Age", "Adress", "Email", "Registered since" 
        };
        public DisplayCookInformations(Cook c)
        {
            this.c = c;
            BuildTabInfos();
        }
        //Aim : making the display of the information easier on the cook profile page
        public string[] TabInfos;
        private void BuildTabInfos()
        {
            TabInfos = new string[]
            {
                c.Nickname, c.LastName, c.FirstName, c.Gender, Convert.ToString(c.Age), c.Address, 
                c.Email, c.DateRegister.ToString()
            };
        }
    }
}