using System;
using System.Collections.Generic;
using System.Text;

// 09/28/2020 10:14 am - SSN - [20200928-1007] - [001] - M03-07 - FriendViewer - The FriendControl

namespace FriendViewer.Model
{
    public class Friend
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }
        public byte[] Image { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
