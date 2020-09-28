using System.Collections.Generic;
using FriendViewer.Model;

namespace FriendViewer.DataProvider
{
    public interface IFriendDataProvider
    {
        IEnumerable<Friend> LoadFriends();
    }
}