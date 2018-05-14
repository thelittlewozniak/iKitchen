using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using onessaye.Models.POCO;

//Bisconti Flavian

namespace onessaye.Models.DAL
{
    public class RecipeDAL : DbContext
    {
        private DbConnection dbc;
        //Builder
        public RecipeDAL()
        {
            dbc = new DbConnection();
        }
        //Methods
        public void AddRecipe(string cook_nickname, Recipe recipe)
        {
            dbc.DbRecipe.Add(recipe);
            dbc.DbCook.SingleOrDefault(c => c.Nickname == cook_nickname).AddRecipe(recipe);
            dbc.SaveChanges();
        }
        public List<Recipe> GetRecipesOfCook(Cook cook)
        {
            List<Recipe> L_Recipes = new List<Recipe>();
            if (cook.ListRecipes != null)
            {
                foreach (Recipe r1 in cook.ListRecipes)
                {
                    foreach (Recipe r2 in dbc.DbRecipe)
                    {
                        if (r1.Id == r2.Id) L_Recipes.Add(r1);
                    }
                }
            }
            return L_Recipes;
        }
    }
}