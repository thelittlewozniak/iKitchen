using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.DAL
{
    public class IngredientDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double UnitPrice { get; set; }
        public string Discriminator { get; set; }
        public int Recipe_Id { get; set; }
    }
}