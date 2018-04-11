using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Catalog
    {
        private List<Dish> listDishes;
        private string thema;
        public List<Dish> GetDishes => listDishes;
        public string GetThema => thema;
        public Catalog(List<Dish> listDishes,string thema)
        {
            this.listDishes = listDishes;
            this.thema = thema;
        }
        public void AddDish(Dish newDish) => listDishes.Add(newDish);
    }
}
