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
    }
}