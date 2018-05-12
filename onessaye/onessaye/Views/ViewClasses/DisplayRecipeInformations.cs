using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;

//Bisconti Flavian

namespace onessaye.Views.ViewClasses
{
    public class DisplayRecipeInformations
    {
        public Recipe r = null;
        public DisplayRecipeInformations(Recipe r)
        {
            this.r = r;
        }
        public string ReturnCostPrice()
        {
            return String.Format("{0:###.00}",r.CalculCostPrice());
        }
        public string ReturnSellingPrice()
        {
            return String.Format("{0:###.00}", r.CalculSellingPrice());
        }
    }
}