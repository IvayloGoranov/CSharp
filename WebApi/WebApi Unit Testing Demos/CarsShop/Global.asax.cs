using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CarsShop.Models.BindingModels;
using CarsShop.Models.Entities;
using CarsShop.Models.ViewModels;

namespace CarsShop
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Car, CarVm>();
                expression.CreateMap<CarBm, Car>();
            });
        }
    }
}
