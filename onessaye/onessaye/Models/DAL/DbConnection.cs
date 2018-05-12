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
            }
        }
    }
}