using Autofac;
using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.View;
using FriendStorage.UI.ViewModel;
using Prism.Events;

namespace FriendStorage.UI.Startup
{
    public class BootStrapper
    {
        public IContainer BootStrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();

            builder.RegisterType<FriendEditViewModel>().As<IFriendEditViewModel>();

            builder.RegisterType<FriendDataProvider>().As<IFriendDataProvider>();

            builder.RegisterType<NavigationDataProvider>().As<INavigationDataProvider>();

            builder.RegisterType<FileDataService>().As<IDataService>();

            return builder.Build();
        }
    }
}
