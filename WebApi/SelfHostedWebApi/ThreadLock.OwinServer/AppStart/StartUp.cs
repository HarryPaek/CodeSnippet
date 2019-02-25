﻿using ePlatform.Common.DI;
using ePlatform.WebApi.DI;
using Owin;
using System.Web.Http;

namespace ThreadLock.OwinServer
{
    public class StartUp
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityDependencyResolver(IoC.DependencyResolver);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
