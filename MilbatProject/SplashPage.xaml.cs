using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;
using MilbatProject.ViewModels;

namespace MilbatProject
{
    public partial class SplashPage : PhoneApplicationPage
    {
        public SplashPage()
        {
            InitializeComponent();

            //Call MainPage from ExtendedSplashScreen after some delay
            Splash_Screen();
        }

        async void Splash_Screen()
        {
            await Task.Delay(TimeSpan.FromSeconds(3)); // set your desired delay
            if (DisclaimerPageViewModel.IsDisclaimerSigned())
            {
                SettingsPageViewModel.SettingsPageInit();
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative)); // call MainPage
            }
            else
            {
                SettingsPageViewModel.CreateNewSettingsFile();
                SettingsPageViewModel.SettingsPageInit();
                NavigationService.Navigate(new Uri("/DisclaimerPage.xaml", UriKind.Relative));
            }
        }
    }
}

