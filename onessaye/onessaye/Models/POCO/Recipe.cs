using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Bisconti Flavian

namespace onessaye.Models.POCO
{
    public class Recipe
    {
        //Attributes
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Type { get; set; }
        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }
        public List<Ingredient> ListIngredients { get; set; }
        public List<Comment> ListComments { get; set; }
    }
}