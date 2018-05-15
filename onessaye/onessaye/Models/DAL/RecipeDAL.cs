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
        //public void AddIngredient(Recipe r, Ingredient i)
        //{
        //    dbc.DbRecipe.SingleOrDefault(recipe => recipe.Id == r.Id).AddIngredient(i);
        //    dbc.SaveChanges();
        //}
        //public void AddPricesToRecipe(string cook_nickname, float cost_price, float selling_price)
        //{
        //    dbc.DbCook.SingleOrDefault(c => c.Nickname == cook_nickname).ListRecipes.Last().CostPrice = cost_price;
        //    dbc.DbCook.SingleOrDefault(c => c.Nickname == cook_nickname).ListRecipes.Last().SellingPrice = selling_price;
        //    dbc.SaveChanges();
        //}
    }
}