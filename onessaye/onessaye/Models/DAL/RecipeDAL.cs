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
        public Array GetRecipes()
        {
            return dbc.DbRecipe.ToArray();
        }
        public Recipe GetRecipe(int id)
        {
            return dbc.DbRecipe.SingleOrDefault(r => r.Id == id);
        }
        public List<Ingredient> GetIngredients(int id)
        {
            return dbc.DbRecipe.SingleOrDefault(r => r.Id == id).ListIngredients;
        }
    }
}