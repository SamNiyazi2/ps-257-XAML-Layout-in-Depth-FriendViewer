using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;


// 09/29/2020 09:05 am - SSN - [20200929-0720] - [004] - M04-09 - Translate an element
// 09/29/2020 12:00 pm - SSN - [20200929-1048] - [003] - M04-10 - FriendView: Navigation flyout
// Copied from "C:\Sams_P\PS\xaml-layout-in-depth\Homework\TranslateTransformWPF\Extensions"

//namespace TranslateTransformWPF.Extensions
namespace FriendViewer.Extensions

{
    public static class TranslateTransformExtensions
    {
        public static void AnimateTo(this TranslateTransform translateTransform, Point point)
        {

            StartAnimation(translateTransform, TranslateTransform.XProperty, point.X);
            StartAnimation(translateTransform, TranslateTransform.YProperty, point.Y);
        }

        private static void StartAnimation(TranslateTransform translateTransform, DependencyProperty dependencyProperty, double toValue)
        {

            EasingFunctionBase easingFunctionBase = new QuarticEase();
            easingFunctionBase = new QuinticEase();
            easingFunctionBase = new QuarticEase();


            var animation = new DoubleAnimation
            {
                To = toValue,
                Duration = new Duration(TimeSpan.FromSeconds(0.7)),
                EasingFunction = easingFunctionBase
            };

            translateTransform.BeginAnimation(dependencyProperty, animation);

        }


    }
}