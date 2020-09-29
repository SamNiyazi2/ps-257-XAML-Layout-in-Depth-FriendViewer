using FriendViewer.DataProvider;
using FriendViewer.DesignTimeData;
using FriendViewer.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FriendViewer.ViewModel
{
    public class MainViewModel : Observable
    {
        private readonly IFriendDataProvider _dataProvider;
        private Friend _selectedFriend;
        public ObservableCollection<Friend> Friends { get; set; }

        private bool _IsLoading;
        public bool IsLoading
        {
            get => _IsLoading;
            set
            {
                _IsLoading = value;
                OnPropertyChanged();
            }
        }

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Friends = new ObservableCollection<Friend>();
            IsLoading = false;
            LoadDataAsync();
        }

        // 09/29/2020 04:05 pm - SSN - [20200929-1605] - [001] - M05-03 - FriendViewer: Loading overlay


        private async Task LoadDataAsync()
        {
            IsLoading = true;
            try
            {

                var friends = await Task.Run(() => _dataProvider.LoadFriends());

                foreach (var friend in friends)
                {
                    Friends.Add(friend);
                }

                SelectedFriend = Friends.Count > 0 ? Friends.First() : null;

            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                IsLoading = false;
            }

        }



    }
}
