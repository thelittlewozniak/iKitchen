﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Recipe
    {
        public string Name { get; set; }
        public float SellingPrice { get; set; }
        public List<Ingredient> ListIngredient { get; set; }
        public List<Comment> ListComments { get; set; }
    }
}