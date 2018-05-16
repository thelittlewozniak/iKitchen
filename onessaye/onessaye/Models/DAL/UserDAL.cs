using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onessaye.Models.POCO;
using onessaye.Models.EXCEPTIONS;

//Bisconti Flavian

namespace onessaye.Models.DAL
{
    public class UserDAL 
    {
        private DbConnection dbc;
        //Builder
        public UserDAL()
        {
            dbc = new DbConnection();
        }
        //Methods
        public void AddCook(Cook c)
        {
            dbc.DbCook.Add(c);
            dbc.SaveChanges();
        }
        public Cook GetCook(string nickname)
        {
            Cook cook = dbc.DbCook.FirstOrDefault(u => u.Nickname == nickname);
            return cook;
        }
        public Neighbor GetNeighbor(string nickname)
        {
            Neighbor neighbor = dbc.DbNeighbor.FirstOrDefault(u => u.Nickname == nickname);
            if (neighbor != null) return neighbor;
            else
            {
                UnableToLogInException ex = new UnableToLogInException("Impossible to log you in", "The nickname entered doesn't exist within the database");
                ex.Data.Add("TimeStamp", String.Format("An error occured at ", DateTime.Now));
                ex.Data.Add("Cause", $"The nickname {nickname} is unknown");
                throw ex;
            }
        }
        public void AddRecipe(string cook_nickname, Recipe recipe)
        {
            dbc.DbCook.SingleOrDefault(c => c.Nickname == cook_nickname).AddRecipe(recipe);
            dbc.SaveChanges();
        }
        public List<Recipe> GetRecipes(Cook cook)
        {
            List<Recipe> L_Recipes = new List<Recipe>();
            Cook Cook = dbc.DbCook.SingleOrDefault(c => c.Nickname == cook.Nickname);
            L_Recipes = Cook.ListRecipes;
            return L_Recipes;
        }
        public List<Recipe> GetRecipes()
        {
            return dbc.DbRecipe.ToList();
        }
        public void DeleteRecipe(int id)
        {
            dbc.DbRecipe.SingleOrDefault(r => r.Id == id).ListIngredients.Clear();
            dbc.SaveChanges();
            dbc.DbRecipe.Remove(dbc.DbRecipe.SingleOrDefault(r => r.Id == id));
            dbc.SaveChanges();
        }
    }
}