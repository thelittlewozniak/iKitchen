using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Bisconti Flavian

namespace onessaye.Models.POCO
{
    public abstract class Ingredient 
    {
        //Attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double UnitPrice { get; set; }
        //Builder
        public Ingredient(string n, double a, double up)
        {
            Name = n;
            Amount = a;
            UnitPrice = up;
        }
        public Ingredient() { }
        //Methods
        public abstract float CalculCostIngredient();
    }
}