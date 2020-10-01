using FriendViewer.Commands;
using FriendViewer.DataProvider;
using FriendViewer.DesignTimeData;
using FriendViewer.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendViewer.ViewModel
{
    public class MainViewModel : Observable
    {
        private readonly IFriendDataProvider _dataProvider;
        private Friend _selectedFriend;
        public ObservableCollection<Friend> Friends { get; set; }

        // 10/01/2020 11:20 am - SSN - [20201001-1114] - [002] - M05-12 - FriendViewer: New main area
        public ObservableCollection<Friend> MainAreaFriends { get; set; }


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
                // 10/01/2020 11:22 am - SSN - [20201001-1114] - [003] - M05-12 - FriendViewer: New main area
                if (_selectedFriend != null)
                {
                    if (MainAreaFriends.Contains(_selectedFriend))
                    {
                        MainAreaFriends.Move(MainAreaFriends.IndexOf(_selectedFriend), 0);
                    }
                    else
                    {
                        MainAreaFriends.Insert(0, _selectedFriend);
                    }
                }
            }
        }


        // 10/01/2020 11:24 am - SSN - [20201001-1114] - [004] - M05-12 - FriendViewer: New main area
        public ICommand CloseMainAreaFriendCommand { get; private set; }

        private void OnCloseMainAreaFriendExecuted(object obj)
        {
            var friend = obj as Friend;
            if (friend != null && MainAreaFriends.Contains(friend))
            {
                MainAreaFriends.Remove(friend);
                if (SelectedFriend == friend)
                {
                    SelectedFriend = null;
                }
            }
        }



        public MainViewModel(IFriendDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Friends = new ObservableCollection<Friend>();
            MainAreaFriends = new ObservableCollection<Friend>();

            // 10/01/2020 12:00 pm - SSN - [20201001-1114] - [005] - M05-12 - FriendViewer: New main area
            CloseMainAreaFriendCommand = new DelegateCommand(OnCloseMainAreaFriendExecuted);

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
