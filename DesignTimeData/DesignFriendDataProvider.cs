using FriendViewer.DataProvider;
using FriendViewer.Model;
using System.Collections.Generic;

namespace FriendViewer.DesignTimeData
{
    class DesignFriendDataProvider : IFriendDataProvider
    {
        public IEnumerable<Friend> LoadFriends()
        {
            yield return new DesignFriend();
            yield return new DesignFriend { FirstName = "Julia" };
            yield return new DesignFriend { FirstName = "Anna" };
            yield return new DesignFriend { FirstName = "Sara" };
        }
    }
}
