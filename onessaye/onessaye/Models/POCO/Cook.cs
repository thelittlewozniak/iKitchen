using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Cook:User
    {
        public string Address { get; set; }
        public List<Recipe> ListRecipes { get; set; }
    }
}