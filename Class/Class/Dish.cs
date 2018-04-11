using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Dish
    {
        private List<string[]> listComments;
        private List<string> listIngredients;
        private string thema;
        private string type;
        private float price;
        public List<string[]> GetComments => listComments;
        public List<string> GetIngredient => listIngredients;
        public string GetThema => thema;
        public string GetTypeDish => type;
        public float GetPrice => price;
        public Dish(List<string[]> listComments,List<string> listIngredients,string thema,string type, float price)
        {
            this.listComments =listComments;
            this.listIngredients = listIngredients;
            this.thema = thema;
            this.type = type;
            this.price = price;
        }
        public void AddDateToSchedule(DateTime date, Schedule schedule) => schedule.AddAvailableDate(date);
    }
}
