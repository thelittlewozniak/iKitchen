using System;
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
                name: "RecipeForm",
                url: "Recipe/DisplayRecipeForm");

            routes.MapRoute(
                name: "AcceptRecipe",
                url: "Cook/AcceptedRecipe/{id}",
                defaults: new { id = UrlParameter.Optional });
        }
    }
}
