using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.DAL
{
    public class RecipeDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float CostPrice { get; set; }
        public float SellingPrice { get; set; }
        public DateTime Date { get; set; }
        public int Schedules_Id { get; set; }
        public int Cook_Id { get; set; }
    }
}