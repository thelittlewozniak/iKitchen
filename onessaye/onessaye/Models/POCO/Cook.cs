using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Bisconti Flavian

namespace onessaye.Models.POCO
{
    public class Cook:User
    {
        //Attributes
        public string Address { get; set; }
        public List<Recipe> ListRecipes { get; set; }
        //Methods
        public Cook() { ListRecipes = new List<Recipe>(); }
        public void AddRecipe(Recipe recipe)
        {
            ListRecipes.Add(recipe);
        }
    }
}