using System.Windows.Input;

using Prism.Events;

using FriendStorage.UI.Command;
using FriendStorage.UI.Events;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private IEventAggregator eventAggregator;
        private string displayMember;

        public NavigationItemViewModel(int id, string displayMember, 
            IEventAggregator eventAggregator)
        {
            this.Id = id;
            this.DisplayMember = displayMember;
            this.eventAggregator = eventAggregator;

            this.OpenFriendEditViewCommand = new DelegateCommand(OnFriendsEditViewExecute);          
        }

        public int Id { get; set; }

        public string DisplayMember
        {
            get
            {
                return this.displayMember;
            }

            set
            {
                this.displayMember = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand OpenFriendEditViewCommand { get; private set; }

        private void OnFriendsEditViewExecute(object parameter)
        {
            this.eventAggregator.GetEvent<OpenFriendEditViewEvent>().Publish(this.Id);
        }
    }
}
