using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Order
    {
        private DateTime datetime;
        private float amount;
        private Dish dish;
        public DateTime GetDateTime => datetime;
        public float GetAmount => amount;
        public Dish GetDish => dish;
    }
}
