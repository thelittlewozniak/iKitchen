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
        public override float CalculCostIngredient()
        {
            return (float)(UnitPrice * (Amount / 200));
        }
        public override string ToString()
        {
            string price = String.Format("{0:0.00}", CalculCostIngredient());
            return $"{Amount}{Unit} of {Name} for {price} euros";
        }
    }
}