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
        public void AddRecipe(Recipe r)
        {
            dbc.DbRecipe.Add(r);
            dbc.SaveChanges();
        }
        public List<Recipe> GetListRecipes()
        {
            return dbc.DbRecipe.ToList();
        }
    }
}