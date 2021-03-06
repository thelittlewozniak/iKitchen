﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace onessaye
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //Bisconti Flavian
            routes.MapRoute(
                name: "AddRecipe",
                url: "Recipe/DisplayRecipeForm/{Cook}/{NbIngredients}",
                defaults: new { controller = "Recipe", action = "DisplayRecipeForm", NbIngredients = UrlParameter.Optional});

            routes.MapRoute(
                name: "DeletedRecipe",
                url: "Recipe/DeleteRecipe");
            //Nathan Pire Zaretti Quentin
            routes.MapRoute(
                name: "Schedule",
                url: "Schedule/Index/{id_Cook}",
                defaults: new { controller = "ScheduleController", action = "Index", id_Cook = UrlParameter.Optional });
            routes.MapRoute(
                name: "MakeOrder",
                url: "Order/AddOrder/{id_Cook}",
                defaults: new { controller = "OrderController", action = "AddOrder", id_Cook = UrlParameter.Optional });
            routes.MapRoute(
                name: "Order",
                url: "Order/Order/{id_recipe}",
                defaults: new { controller = "OrderController", action = "Order", id_recipe = UrlParameter.Optional });
        }
    }
}
