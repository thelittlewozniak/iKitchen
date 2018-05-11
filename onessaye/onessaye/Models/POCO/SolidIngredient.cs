using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Bisconti Flavian

namespace onessaye.Models.POCO
{
    public class SolidIngredient : Ingredient
    {
        //Attribute
        public static string Unit = "g";
        //Builder
        public SolidIngredient(string name, double amount, double unitPrice):base(name, amount, unitPrice) { }
        //Methods
        public override double CalculCostIngredient()
        {
            return UnitPrice * (Amount / 200);
        }
        public override string ToString()
        {
            return $"{Amount} {Unit} of {Name} for {CalculCostIngredient()}";
        }
    }
}