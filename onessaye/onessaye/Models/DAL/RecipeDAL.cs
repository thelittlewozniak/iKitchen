﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
            return dbc.DbRecipe.Include(c=>c.ListIngredients).Include(c=>c.Schedules.ListDate).SingleOrDefault(r => r.Id == id);
        }
    }
}