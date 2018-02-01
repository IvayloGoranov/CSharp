using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using Prism.Events;

using FriendStorage.UI.Events;
using FriendStorage.UI.Command;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Func<IFriendEditViewModel> friendEditViewModelCreator;

        private IFriendEditViewModel selectedFriendEditViewModel;

        public MainViewModel(INavigationViewModel navigationViewModel, 
            Func<IFriendEditViewModel> friendEditViewModelCreator, IEventAggregator eventAggregator)
        {
            this.NavigationViewModel = navigationViewModel;
            this.friendEditViewModelCreator = friendEditViewModelCreator;
            eventAggregator.GetEvent<OpenFriendEditViewEvent>().Subscribe(OnOpenFriendEditView);

            this.FriendEditViewModels = new ObservableCollection<IFriendEditViewModel>();

            this.CloseFriendTabCommand = new DelegateCommand(OnCloseFriendTabExecute);

            this.AddFriendCommand = new DelegateCommand(OnAddFriendExecute);
        }

        public ICommand AddFriendCommand { get; private set; }

        public ICommand CloseFriendTabCommand { get; private set; }

        public INavigationViewModel NavigationViewModel { get; private set; }

        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels { get; private set; }

        public IFriendEditViewModel SelectedFriendEditViewModel
        {
            get
            {
                return this.selectedFriendEditViewModel;
            }

            set
            {
                this.selectedFriendEditViewModel = value;
                this.OnPropertyChanged();
            }
        }

        public void Load()
        {
            this.NavigationViewModel.Load();
        }

        private void OnOpenFriendEditView(int friendId)
        {
            var friendEditViewModel = this.FriendEditViewModels.
                SingleOrDefault(vm => vm.Friend.Id == friendId);
            if (friendEditViewModel == null)
            {
                friendEditViewModel = this.friendEditViewModelCreator();
                this.FriendEditViewModels.Add(friendEditViewModel);
                friendEditViewModel.Load(friendId);
            }
            
            this.SelectedFriendEditViewModel = friendEditViewModel;
        }

        private void OnCloseFriendTabExecute(object obj)
        {
            var friendEditViewModel = (IFriendEditViewModel)obj;
            this.FriendEditViewModels.Remove(friendEditViewModel);
        }

        private void OnAddFriendExecute(object obj)
        {
            var friendEditViewModel = this.friendEditViewModelCreator();
            this.FriendEditViewModels.Add(friendEditViewModel);
            friendEditViewModel.Load(null);
            
            this.SelectedFriendEditViewModel = friendEditViewModel;
        }
    }
}
