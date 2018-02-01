using System.Collections.ObjectModel;

using FriendStorage.Model;

using Prism.Events;

using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Events;
using System;
using System.Linq;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IEventAggregator eventAggregator;
        private INavigationDataProvider navigationDataProvider;

        public NavigationViewModel(INavigationDataProvider navigationDataProvider,
            IEventAggregator eventAggregator)
        {
            this.navigationDataProvider = navigationDataProvider;
            this.Friends = new ObservableCollection<NavigationItemViewModel>();
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<FriendSavedEvent>().Subscribe(OnFriendSaved);
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; private set; }

        public void Load()
        {
            this.Friends.Clear();
            foreach (var friend in this.navigationDataProvider.GetAllFriends())
            {
                this.Friends.Add(new NavigationItemViewModel(friend.Id, friend.DisplayMember, 
                    this.eventAggregator));
            }
        }

        private void OnFriendSaved(Friend friend)
        {
            var navigationItem = this.Friends.SingleOrDefault(f => f.Id == friend.Id);
            if (navigationItem != null)
            {
                navigationItem.DisplayMember = string.Format("{0} {1}", friend.FirstName, friend.LastName);
            }
            else
            {
                navigationItem = new NavigationItemViewModel(friend.Id, string.Format("{0} {1}", friend.FirstName, friend.LastName),
                    this.eventAggregator);
                this.Friends.Add(navigationItem);
            }
        }
    }
}
