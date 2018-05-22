using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Bisconti Flavian

namespace onessaye.Models.POCO
{
    public class Cook:User
    {
        public string Address { get; set; }
        //Attributes
        public List<Recipe> ListRecipes { get; set; }
        //Builder
        public Cook() { ListRecipes = new List<Recipe>(); }
        //Methods
        public void AddRecipe(Recipe recipe)
        {
            ListRecipes.Add(recipe);
        }
    }
}