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
            RecipeDb db=dbc.DbRecipe.SingleOrDefault(r => r.Id == id);
            List<DatesDB> dbdate = dbc.dbDate.ToList();
            List<DatesDB> dbDateCorrect = (from date in dbdate where date.Schedule_Id==db.Schedules_Id select date).ToList();
            List<Date> dates = new List<Date>();
            foreach (DatesDB item in dbDateCorrect)
            {
                dates.Add(new Date(item.DateAvailable,item.QuantityLeft));
            }
            Schedule sched = new Schedule();
            sched.ListDate = dates;
            List<IngredientDb> dbingredient = dbc.dbIngredient.ToList();
            List<IngredientDb> dbcorrect = (from ing in dbingredient where ing.Recipe_Id == db.Id select ing).ToList();
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (IngredientDb item in dbcorrect)
            {
                switch (item.Discriminator)
                {
                    case "UnitIngredient":ingredients.Add(new SolidIngredient(item.Name, item.Amount, item.UnitPrice));
                    break;
                    default:
                    break;
                }
            }
            Recipe newrecipe = new Recipe(db.Name, db.Type, db.CostPrice, db.SellingPrice, db.Date, ingredients, null,sched);
            return newrecipe;
        }
    }
}