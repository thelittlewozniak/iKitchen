using onessaye.Models.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace onessaye.Models.DAL
{
    public class ScheduleDAL : DbContext
    {
        private DbConnection dbc;
        //Builder
        public ScheduleDAL()
        {
            dbc = new DbConnection();
        }
        public List<Schedule> GetSchedules()
        {
            return dbc.DbSchedules.Include(r => r.ListDate).ToList();
        }
        public Recipe GetRecipeById(int id)
        {
            return dbc.DbRecipe.Include(r => r.Schedules).Include(r => r.Schedules.ListDate).SingleOrDefault(r => r.Id == id);
        }
        public List<Recipe> GetSchedulesPerUser(int id)
        {
            Cook cook= dbc.DbCook.Include(r=>r.ListRecipes).SingleOrDefault(r=>r.Id==id);
            List<Recipe> recipes = new List<Recipe>();
            foreach (Recipe recipe in cook.ListRecipes)
            {
                recipes.Add(GetRecipeById(recipe.Id));
            }
            return recipes;
        }
    }
}