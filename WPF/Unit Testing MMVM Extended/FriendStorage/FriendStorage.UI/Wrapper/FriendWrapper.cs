using System;
using System.Runtime.CompilerServices;
using FriendStorage.Model;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI.Wrapper
{
    public class FriendWrapper : ViewModelBase
    {
        private Friend friend;
        private bool isChanged;

        public FriendWrapper(Friend friend)
        {
            this.friend = friend;
        }

        public Friend Model
        {
            get
            {
                return this.friend;
            }
        }

        public bool IsChanged
        {
            get
            {
                return this.isChanged;
            }

            set
            {
                this.isChanged = value;
                this.OnPropertyChanged();
            }
        }

        public void AcceptChanges()
        {
            this.IsChanged = false;
        }

        public int Id
        {
            get
            {
                return this.friend.Id;
            }

            set
            {
                this.friend.Id = value;
                this.OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get
            {
                return this.friend.FirstName;
            }

            set
            {
                this.friend.FirstName = value;
                this.OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return this.friend.LastName;
            }

            set
            {
                this.friend.LastName = value;
                this.OnPropertyChanged();
            }
        }

        public DateTime? Birthday
        {
            get
            {
                return this.friend.Birthday;
            }

            set
            {
                this.friend.Birthday = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get
            {
                return this.friend.IsDeveloper;
            }

            set
            {
                this.friend.IsDeveloper = value;
                this.OnPropertyChanged();
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName != nameof(this.IsChanged))
            {
                this.IsChanged = true;
            }
        }
    }
}
