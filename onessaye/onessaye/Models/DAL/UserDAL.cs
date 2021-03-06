﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using onessaye.Models.POCO;
using onessaye.Models.EXCEPTIONS;
using System.Data.Entity;
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
            Cook cook = dbc.DbCook.Include(c=>c.ListRecipes).FirstOrDefault(u => u.Nickname == nickname);
            return cook;
        }
        public Cook GetCook(int  id)
        {
            Cook cook = dbc.DbCook.Include(c => c.ListRecipes).FirstOrDefault(u => u.Id == id);
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
            Cook Cook = dbc.DbCook.Include(c => c.ListRecipes).SingleOrDefault(c => c.Nickname == cook.Nickname);
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
        public void AddOrder(int id, Order order)
        {
            dbc.DbNeighbor.SingleOrDefault(c => c.Id == id).AddOrder(order);
            List<Date> listdate = dbc.DbDate.ToList();
            foreach (Date date in order.Recipe.Schedules.ListDate)
            {
                if (date.DateAvailable == order.ReceiptDate)
                {
                    dbc.DbDate.SingleOrDefault(c => c.Id == date.Id).RemoveQuantityLeft(1);
                }
            }
        }
        public void UpdateRecipe(int id, string name, List<Ingredient> l_ing, float cost_price, float selling_price)
        {
            dbc.DbRecipe.SingleOrDefault(r => r.Id == id).Name = name;
            for(int i=0;i<dbc.DbRecipe.SingleOrDefault(r => r.Id == id).ListIngredients.Count;i++)
            {
                int idIng = dbc.DbRecipe.SingleOrDefault(r => r.Id == id).ListIngredients[i].Id;
                dbc.DbIngredient.Remove(dbc.DbIngredient.SingleOrDefault(ing => ing.Id == idIng));
                dbc.SaveChanges();
            }
            dbc.DbRecipe.SingleOrDefault(r => r.Id == id).ListIngredients = l_ing;
            dbc.DbRecipe.SingleOrDefault(r => r.Id == id).CostPrice = cost_price;
            dbc.DbRecipe.SingleOrDefault(r => r.Id == id).SellingPrice = selling_price;
            dbc.DbRecipe.SingleOrDefault(r => r.Id == id).Date = DateTime.Now;
            dbc.SaveChanges();
        }
    }
}