using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace blog_project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PostsID",
                url: "posts/{id}",
                defaults: new { controller = "Post", action = "Details" }
            );
            routes.MapRoute(
               name: "PostsIndex",
               url: "posts",
               defaults: new { controller = "Post", action = "Index" }
           );
            routes.MapRoute(
                name: "UpdateDefault",
                url: "{controller}/Update",
                defaults: new { controller = "Post", action = "Index"}
            );
            routes.MapRoute(
                name: "DetailsDefault",
                url: "{controller}/Details",
                defaults: new { controller = "Post", action = "Index" }
            );
            routes.MapRoute(
                name: "DeleteDefault",
                url: "{controller}/Delete",
                defaults: new { controller = "Post", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DefaultBlank",
                url: "",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
