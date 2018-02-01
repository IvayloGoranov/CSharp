[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LinkedIn.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LinkedIn.Web.App_Start.NinjectWebCommon), "Stop")]

namespace LinkedIn.Web.App_Start
{
    using System;
    using System.Web;
    using Data;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    using LinkedIn.Data.Repositories;
    using LinkedIn.Web.Infrastructure.CacheService;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                ObjectFactory.InitializeKernel(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<LinkedInContext>().To<LinkedInContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>))
                .WithConstructorArgument("context", kernel.Get<LinkedInContext>());
            kernel.Bind<LinkedInData>().To<LinkedInData>();
            kernel.Bind<ICacheService>().To<MemoryCacheService>();
        }

        //private static void RegisterServices(IKernel kernel)
        //{
        //    kernel.Bind(k => k.FromAssemblyContaining<IVggLinkedInData>()
        //        .SelectAllClasses()
        //        .BindDefaultInterface()
        //        .Configure(b => b.InRequestScope()));
        //}
    }
}
