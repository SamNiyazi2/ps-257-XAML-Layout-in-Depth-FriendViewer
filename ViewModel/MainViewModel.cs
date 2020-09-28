using FriendViewer.DataProvider;
using FriendViewer.DesignTimeData;
using FriendViewer.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace FriendViewer.ViewModel
{
    public class MainViewModel : Observable
    {
        private readonly IFriendDataProvider _dataProvider;
        private Friend _selectedFriend;

        public MainViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Friends = new ObservableCollection<Friend>();

            LoadData();
        }

        private void LoadData()
        {
            var friends = _dataProvider.LoadFriends();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }

            SelectedFriend = Friends.Count > 0 ? Friends.First() : null;
        }

        public ObservableCollection<Friend> Friends { get; set; }

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }
    }
}
