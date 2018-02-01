using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendStorage.Model;
using FriendStorage.DataAccess;

namespace FriendStorage.UI.DataProvider
{
    public class FriendDataProvider : IFriendDataProvider
    {
        private Func<IDataService> dataServiceCreator;

        public FriendDataProvider(Func<IDataService> dataServiceCreator)
        {
            this.dataServiceCreator = dataServiceCreator;       
        }

        public void DeletFriend(int id)
        {
            using (var dataService = this.dataServiceCreator())
            {
                dataService.DeleteFriend(id);
            }
        }

        public Friend GetFriendById(int id)
        {
            using (var dataService = this.dataServiceCreator())
            {
                return dataService.GetFriendById(id);
            }
        }

        public void SaveFriend(Friend friend)
        {
            using (var dataService = this.dataServiceCreator())
            {
                dataService.SaveFriend(friend);
            }
        }
    }
}
