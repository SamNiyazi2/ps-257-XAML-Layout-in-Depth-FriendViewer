using FriendViewer.Model;
using System;
using System.Windows;
using System.Windows.Media.Imaging;


// 09/28/2020 10:25 am - SSN - [20200928-1007] - [002] - M03-07 - FriendViewer - The FriendControl

// Copied from download: 3-xaml-layout-in-depth-m3-exercise-files\FriendViewer\DesignTimeData

namespace FriendViewer.DesignTimeData
{
    public class DesignFriend : Friend
    {
        public DesignFriend()
        {
            FirstName = "Thomas";
            LastName = "Huber";
            CellPhone = "+49 (0) 123456789";
            Email = "thomas@thomasclaudiushuber.com";
            Homepage = "www.thomasclaudiushuber.com";
            SetImageProperty();
        }

        private void SetImageProperty()
        { 
            var streamResourceInfo = 
                Application.GetResourceStream(
                new Uri("FriendViewer;component/DesignTimeData/Images/thomas.jpg", UriKind.Relative));

            var length = streamResourceInfo.Stream.Length;
            byte[] image = new byte[length];
            streamResourceInfo.Stream.Read(image, 0, (int)length);

            Image = image;
        }
    }
}
