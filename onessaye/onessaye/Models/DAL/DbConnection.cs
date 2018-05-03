using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using onessaye.Models.POCO;

namespace onessaye.Models.DAL
{
    public class DbConnection : DbContext
    {
        public DbSet<Recipe> DbRecipe { get; set; }
        //public DbConnection()
        //{
        //    Database.SetInitializer(new DbConnectionInitializer());
        //}
    }
}