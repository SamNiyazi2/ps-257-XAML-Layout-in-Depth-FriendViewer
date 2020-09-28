using System.Windows;
using FriendViewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendViewer.DataProvider
{
    public class FriendDataProvider : IFriendDataProvider
    {
        public IEnumerable<Friend> LoadFriends()
        {
            return new List<Friend>
            {


                new Friend {FirstName = "Thomas", LastName = "Huber",Email = "thomas@thomasclaudiushuber.com",Homepage = "www.thomasclaudiushuber.com", CellPhone = "+49 123456789", Image =GetImage("thomas.jpg") },
                new Friend {FirstName = "Julia", LastName = "Huber",Email = "julia@juhu-design.com",Homepage = "www.juhu-design.com", CellPhone = "+49 987654321",Image= GetImage("julia.jpg")},
                new Friend {FirstName = "Simon", LastName = "Hiener",Email = "simon@...",Homepage = "not created yet", CellPhone = "+49 555666777", },
                new Friend {FirstName = "Andreas", LastName = "Werne",Email = "andi@...",Homepage = "not created yet", CellPhone = "+49 123456789", },
                new Friend {FirstName = "Sandra", LastName = "Matt",Email = "sandra@...",Homepage = "not created yet", CellPhone = "+49 555666777", },
                new Friend {FirstName = "Marcel", LastName = "Zipper",Email = "marcel@...",Homepage = "not created yet", CellPhone = "+49 123456789", },
                new Friend {FirstName = "Kerstin", LastName = "Ganz",Email = "kerstin@...",Homepage = "not created yet", CellPhone = "+49 123456789", },
                new Friend {FirstName = "Sven", LastName = "Pfau",Email = "sven@...",Homepage = "not created yet", CellPhone = "+49 123456789", },
                new Friend {FirstName = "Christine", LastName = "Egin",Email = "christine@...",Homepage = "not created yet", CellPhone = "+49 123456789", },
            };
        }

        private static byte[] GetImage(string fileName)
        {
            var streamResourceInfo = Application.GetResourceStream(new Uri("/DataProvider/Images/" + fileName, UriKind.Relative));
            var length = streamResourceInfo.Stream.Length;
            byte[] image = new byte[length];
            streamResourceInfo.Stream.Read(image, 0, (int)length);

            return image;
        }
    }
}
