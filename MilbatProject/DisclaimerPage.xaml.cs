using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MilbatProject.ViewModels;

namespace MilbatProject
{
    public partial class DisclaimerPage : PhoneApplicationPage
    {
        public DisclaimerPage()
        {
            InitializeComponent();
        }

        private void UserDisclaimerSign_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if(DisclaimerPageViewModel.IsDisclaimerSigned())
            {
                UserDisclaimerSign.IsChecked = true;
                UserDisclaimerSign.IsEnabled = false;
                ApplicationBarIconButton b = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                b.IsEnabled = false; 
                UserDisclaimerSign.Content = "הנך אישרת את התקנון.";
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if((bool)UserDisclaimerSign.IsChecked)
            {
                if (!DisclaimerPageViewModel.IsDisclaimerSigned())
                {
                    UserDisclaimerSign.IsChecked = true;
                    DisclaimerPageViewModel.SignDisclaimer();
                    UserDisclaimerSign.Content = "תודה על אישור התקנון.";
                }
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}