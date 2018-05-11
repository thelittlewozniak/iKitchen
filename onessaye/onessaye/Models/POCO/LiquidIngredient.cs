using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Bisconti Flavian

namespace onessaye.Models.POCO
{
    public class LiquidIngredient : Ingredient
    {
        //Attribute
        public static string Unit = "ml";
        //Builder
        public LiquidIngredient(string name, double amount, double unitPrice) : base(name, amount, unitPrice) { }
        //Methods
        public override double CalculCostIngredient()
        {
            return UnitPrice * (Amount/100);
        }
        public override string ToString()
        {
            return $"{Amount} {Unit} of {Name} for {CalculCostIngredient()}";
        }
    }
}