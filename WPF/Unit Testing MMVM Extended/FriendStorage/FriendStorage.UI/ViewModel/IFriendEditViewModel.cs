
using FriendStorage.Model;
using FriendStorage.UI.Wrapper;

namespace FriendStorage.UI.ViewModel
{
    public interface IFriendEditViewModel
    {
        void Load(int? friendId);

        FriendWrapper Friend { get; }
    }
}
