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
        public DbSet<Ingredient> DbIngredient { get; set; }
        public DbSet<User> DbUser { get; set; }
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
                //Si la base de données contenait des données
                context.DbUser.Add(new User
                {
                    Nickname = "test",
                    Age = 45,
                    Email = "test@test.test",
                    DateRegister =DateTime.Now,
                    Gender = "Male",
                    FirstName = "TestName",
                    LastName = "TestName",
                    Password = "testbordel"
                });
                context.DbUser.Add(new User
                {
                    Nickname = "Beaugosse",
                    Age = 18,
                    Email = "bgdu45@hotmail.be",
                    DateRegister = DateTime.Now,
                    Gender = "Male",
                    FirstName = "Marcel",
                    LastName = "Berger",
                    Password = "eztobefound"
                });
                context.DbUser.Add(new User
                {
                    Nickname = "Cookie",
                    Age = 25,
                    Email = "babar@gmail.be",
                    DateRegister = DateTime.Now,
                    Gender = "Female",
                    FirstName = "Aurélie",
                    LastName = "Coffier",
                    Password = "beautyANDThebEAst4521"
                });
                context.DbUser.Add(new User
                {
                    Nickname = "BougieVerte",
                    Age = 32,
                    Email = "bvblue@outlook.com",
                    DateRegister = DateTime.Now,
                    Gender = "Male",
                    FirstName = "David",
                    LastName = "Trent",
                    Password = "bblabougie"
                });
            }
        }
    }
}