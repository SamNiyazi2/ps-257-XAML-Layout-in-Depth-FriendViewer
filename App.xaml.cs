using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FriendViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // 09/28/2020 12:19 pm - SSN - [20200928-1156] - [003] - M03-08 - FriendViewer: The application layout

            base.OnStartup(e);
            // StartupUri = new Uri("/MainWindow.xaml",UriKind.Relative);
            StartupUri = new Uri("/MainWindow_v02.xaml", UriKind.Relative);
        }
    }
}
