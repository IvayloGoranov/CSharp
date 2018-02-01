using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Enitities;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterUserBm, User>();
                expression.CreateMap<AddCameraBm, Camera>();
                expression.CreateMap<AddCameraBm, AddCameraVm>();
                expression.CreateMap<Camera, EditCameraVm>();
                expression.CreateMap<EditCameraBm, EditCameraVm>();
                expression.CreateMap<EditCameraBm, Camera>();
                expression.CreateMap<Camera, DeleteCameraVm>();
                expression.CreateMap<Camera, DetailsCameraVm>();
                expression.CreateMap<Camera, ShortCameraVm>();
            });
        }
    }
}
