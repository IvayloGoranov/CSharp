
using FriendStorage.Model;

namespace FriendStorage.UI.DataProvider
{
    public interface IFriendDataProvider
    {
        Friend GetFriendById(int id);

        void SaveFriend(Friend friend);

        void DeletFriend(int id);
    }
}
