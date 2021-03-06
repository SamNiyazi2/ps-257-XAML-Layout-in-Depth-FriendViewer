using FriendViewer.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FriendViewer
{
    /// <summary>
    /// Interaction logic for WindowWindow_v02.xaml
    /// </summary>
    public partial class WindowWindow_v02 : Window
    {
        public WindowWindow_v02()
        {
            InitializeComponent();
        }


        // 09/29/2020 11:56 am - SSN - [20200929-1048] - [002] - M04-10 - FriendView: Navigation flyout

        private void FriendControl_MouseEnter(object sender, MouseEventArgs e)
        {
            hideNavigator();
        }


        private void hideNavigator()
        {
            if (navigationControl.IsPinned)
            {
                return;
            }

            GeneralTransform generalTransform = this.TransformToVisual(navigationGrid);
            Point point = generalTransform.Transform(new Point());

            point.X += navigationTransform.X;
            point.X -= navigationColumn.ActualWidth;
            point.Y = 0;

            navigationTransform.AnimateTo(point);
        }

        // 09/29/2020 12:06 pm - SSN - [20200929-1048] - [004] - M04-10 - FriendView: Navigation flyout
        private void NavigationButton_MouseEnter(object sender, MouseEventArgs e)
        {

            if (navigationGrid.Visibility != Visibility.Visible)
            {
                navigationGrid.Visibility = Visibility.Visible;
            }

            navigationTransform.AnimateTo(new Point());

        }


        // 09/30/2020 06:43 am - SSN - [20200929-1911] - [004] - M05-05 - FriendViewer: Pinnable navigation
        private void navigationControl_IsPinnedChanged(object sender, EventArgs e)
        {
            if (navigationControl.IsPinned)
            {
                if (!mainAreaGrid.ColumnDefinitions.Contains(columnToAddOrRemove))
                {
                    mainAreaGrid.ColumnDefinitions.Insert(0, columnToAddOrRemove);
                }
                navigationButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (mainAreaGrid.ColumnDefinitions.Contains(columnToAddOrRemove))
                {
                    mainAreaGrid.ColumnDefinitions.Remove(columnToAddOrRemove);
                }
                navigationButton.Visibility = Visibility.Visible;

            }
        }
    }
}
