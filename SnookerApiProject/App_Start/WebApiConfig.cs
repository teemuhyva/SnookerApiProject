
using SnookerApiProject.GamesServImpl;
using SnookerApiProject.Models;
using SnookerApiProject.Service;
using SnookerApiProject.UserServiceImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace SnookerApiProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUsersService, ModifyUsers>();
            container.RegisterType<IFriends, FriendsServiceImpl>();
            container.RegisterType<IGamesService, GameServiceImpl>();
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
