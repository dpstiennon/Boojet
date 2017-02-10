using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Boojet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(name: "GetTransactions",
                routeTemplate: "api/budget/{userid}/{year}/{month}",
                defaults: new
                {
                    controller = "MonthlyBudgets",
                    userid = RouteParameter.Optional,
                    month = RouteParameter.Optional,
                    year = RouteParameter.Optional
                });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
        }
    }
}