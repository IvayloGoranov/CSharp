using SimpleHttpServer;
using System;
using System.Reflection;

namespace SimpleMVC.App.MVC
{
    public static class MvcEngine
    {
        public static void Run(HttpServer server)
        {
            RegisterAssemblyName();
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Listen();
            }
            catch (Exception e)
            {
                //Log errors
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Current.AssemblyName =
                Assembly.GetExecutingAssembly().GetName().Name;

        }

        private static void RegisterControllers()
        {
            MvcContext.Current.ControllersFolder = "Controllers";
            MvcContext.Current.ControllersSuffix = "Controller";
        }

        private static void RegisterViews()
        {
            MvcContext.Current.ViewsFolder = "Views";
        }

        private static void RegisterModels()
        {
            MvcContext.Current.ModelsFolder = "Models";
        }
    }
}
