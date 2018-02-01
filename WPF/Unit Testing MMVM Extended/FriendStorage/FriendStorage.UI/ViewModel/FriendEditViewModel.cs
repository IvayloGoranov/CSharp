using System.Windows.Input;
using System;

using FriendStorage.Model;
using FriendStorage.UI.Command;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Wrapper;
using System.ComponentModel;
using Prism.Events;
using FriendStorage.UI.Events;
using FriendStorage.UI.Dialogs;

namespace FriendStorage.UI.ViewModel
{
      public class FriendEditViewModel : ViewModelBase, IFriendEditViewModel
      {
        private IFriendDataProvider friendDataProvider;
        private FriendWrapper friend;
        private IEventAggregator eventAggregator;
        private IMessageDialogService dialogService;

        public FriendEditViewModel(IFriendDataProvider friendDataProvider,
            IEventAggregator eventAggregator, IMessageDialogService dialogService)
        {
            this.friendDataProvider = friendDataProvider;
            this.eventAggregator = eventAggregator;
            this.dialogService = dialogService;

            this.SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            this.DeleteCommand = new DelegateCommand(OnDeleteExecute, OnDeleteCanExecute);
        }

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public void Load(int? friendId)
        {
            var friend = friendId.HasValue ? this.friendDataProvider.GetFriendById(friendId.Value) :
                new Friend();
            this.Friend = new FriendWrapper(friend);

            this.Friend.PropertyChanged += Friend_PropertyChanged;

            ((DelegateCommand)this.SaveCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)this.DeleteCommand).RaiseCanExecuteChanged();
        }

        public FriendWrapper Friend
        {
            get
            {
                return this.friend;
            }

            private set
            {
                this.friend = value;
                this.OnPropertyChanged();
            }
        }

        private bool OnSaveCanExecute(object arg)
        {
            return this.Friend != null && this.Friend.IsChanged;
        }

        private void OnSaveExecute(object obj)
        {
            this.friendDataProvider.SaveFriend(this.Friend.Model);
            this.Friend.AcceptChanges();
            this.eventAggregator.GetEvent<FriendSavedEvent>().Publish(this.Friend.Model);
        }

        private bool OnDeleteCanExecute(object arg)
        {
            return this.Friend != null && this.Friend.Id > 0;
        }

        private void OnDeleteExecute(object obj)
        {
        }

        private void Friend_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ((DelegateCommand)this.SaveCommand).RaiseCanExecuteChanged();
        }
    }
}
