using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Bisconti Flavian

namespace onessaye.Models.POCO
{
    public class Recipe
    {
        //Attributes
        public string Name { get; set; }
        public string Topic { get; set; }
        public string Type { get; set; }
        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime Date { get; set; }
        public List<Ingredient> ListIngredients { get; set; }
        public List<Comment> ListComments { get; set; }
        //Builder
        public Recipe(string name, string topic, string type)
        {
            Name = name;
            Topic = topic;
            Type = type;
            ListIngredients = new List<Ingredient>();
        }
        //Methods
        public void AddIngredient(Ingredient i)
        {
            ListIngredients.Add(i);
        }
        public double CalculCostPrice()
        {
            double cost = 0;
            foreach (Ingredient ing in ListIngredients)
            {
                cost += ing.CalculCostIngredient();
            }
            return cost;
        }
        public double CalculSellingPrice()
        {
            return CalculCostPrice() * 1.05;
        }
    }
}