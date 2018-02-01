using System.Collections.ObjectModel;

namespace FriendStorage.UI.ViewModel
{
    public interface INavigationViewModel
    {
        ObservableCollection<NavigationItemViewModel> Friends { get; }

        void Load();
    }
}
