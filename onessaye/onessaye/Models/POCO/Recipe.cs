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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float CostPrice { get; set; }
        public float SellingPrice { get; set; }
        public DateTime Date { get; set; }
        public List<Ingredient> ListIngredients { get; set; }
        public List<Comment> ListComments { get; set; }
        //Builder
        public Recipe(string name, string type)
        {
            Name = name;
            Type = type;
            Date = DateTime.Now;
            ListIngredients = new List<Ingredient>();
        }
        public Recipe() { }
        //Methods
        public void AddIngredient(Ingredient i)
        {
            ListIngredients.Add(i);
        }
        public float CalculCostPrice()
        {
            float cost = 0;
            foreach (Ingredient ing in ListIngredients)
            {
                cost += ing.CalculCostIngredient();
            }
            return cost;
        }
        public float CalculSellingPrice()
        {
            return (float)(CalculCostPrice()*1.05);
        }
        public override string ToString()
        {
            return $"{Name} added the {Date.ToString()}";
        }
    }
}