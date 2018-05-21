using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;

//Bisconti Flavian

namespace onessaye.Views.ViewClasses
{
    public class DisplayRecipeInformation
    {
        public Recipe r = null;
        public DisplayRecipeInformation(Recipe r)
        {
            this.r = r;
        }
        public string ReturnCostPrice()
        {
            return String.Format("{0:00.00}", r.CostPrice);
        }
        public string ReturnSellingPrice()
        {
            return String.Format("{0:00.00}", r.SellingPrice);
        }
        public string ReturnDate()
        {
            return String.Format("{0:d}", r.Date);
        }
        //public string ReturnAvailableDate()
        //{
        //    return r.Schedules.ToString();
        //}
    }
}