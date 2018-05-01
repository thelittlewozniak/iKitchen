using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Catalog
    {
        public DateTime ValidityDate { get; set; }
        public string Topic { get; set; }
        public List<Recipe> ListRecipes { get; set; }
    }
}