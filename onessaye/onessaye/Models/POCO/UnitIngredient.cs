using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class UnitIngredient : Ingredient
    {
        //Attribute
        public static string Unit = "unit(s)";
        //Builder
        public UnitIngredient(string name, double amount, double unitPrice) : base(name, amount, unitPrice) { }
        //Methods
        public override float CalculCostIngredient()
        {
            return (float)(UnitPrice * Amount);
        }
        public override string ToString()
        {
            string price = String.Format("{0:0.00}", CalculCostIngredient());
            return $"{Amount} {Unit} of {Name} for {price} euros";
        }
    }
}