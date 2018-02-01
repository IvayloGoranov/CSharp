using System;
using System.Collections.Generic;

using FriendStorage.Model;
using FriendStorage.DataAccess;

namespace FriendStorage.UI.DataProvider
{
    public class NavigationDataProvider : INavigationDataProvider
    {
        private Func<IDataService> dataServiceCreator;

        public NavigationDataProvider(Func<IDataService> dataServiceCreator)
        {
            this.dataServiceCreator = dataServiceCreator;          
        }

        public IEnumerable<LookupItem> GetAllFriends()
        {
            using (var dataService = this.dataServiceCreator())
            {
                return dataService.GetAllFriends();
            }
        }
    }
}
