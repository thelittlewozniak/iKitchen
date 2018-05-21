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
        public DbSet<Schedule> DbSchedules { get; set; }
        public DbSet<Ingredient> DbIngredient { get; set; }
        public DbSet<Cook> DbCook { get; set; }
        public DbSet<Neighbor> DbNeighbor { get; set; }
        public DbConnection()
        {
            Database.SetInitializer(new DBContextInitializer());
        }
        public class DBContextInitializer : DropCreateDatabaseIfModelChanges<DbConnection>
        {
            //Evite une erreur d'exécution si la base de données est modifiée (Ex. : ajout d'attributs, ...)
            //Détruit la base de données et la recrée
            protected override void Seed(DbConnection context)
            {
                context.DbCook.Add(new Cook{
                    Nickname = "test",
                    Password = "marchebordel",
                    Age = 25,
                    DateRegister = DateTime.Now,
                    Email = "test@test.com",
                    FirstName = "firsttest",
                    Gender = "Male",
                    LastName = "lasttest"
                });
                context.DbCook.Add(new Cook
                {
                    Nickname = "salutlesGens",
                    Password = "crossedfinders",
                    Age = 41,
                    DateRegister = DateTime.Now,
                    Email = "test@test.com",
                    FirstName = "Albert",
                    Gender = "Male",
                    LastName = "Ducoffre"
                });
                context.DbNeighbor.Add(new Neighbor
                {
                    Nickname = "JoliePrune",
                    Password = "prunebleue",
                    Age = 19,
                    DateRegister = DateTime.Now,
                    Email = "test@test.com",
                    FirstName = "Alice",
                    Gender = "Female",
                    LastName = "Cyan"
                });
            }
        }
    }
}