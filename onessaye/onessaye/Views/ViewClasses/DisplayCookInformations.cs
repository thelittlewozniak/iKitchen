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
        public Cook c = null;
        public string[] TabLabels = new string[]
        {
            "Nickname", "Last name", "First name", "Gender", "Age", "Adress", "Email", "Registered since" 
        };
        public string[] TabInfos;
        public DisplayCookInformations(Cook c)
        {
            this.c = c;
            BuildTabInfos();
        }
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