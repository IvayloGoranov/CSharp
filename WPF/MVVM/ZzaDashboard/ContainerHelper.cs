using Microsoft.Practices.Unity;

using ZzaDashboard.Services;

namespace ZzaDashboard
{
    public static class ContainerHelper
    {
        private static IUnityContainer container;

        static ContainerHelper()
        {
            container = new UnityContainer();
            container.RegisterType<ICustomersRepository, CustomersRepository>
                (new ContainerControlledLifetimeManager());       
        }

        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
        }
    }
}
