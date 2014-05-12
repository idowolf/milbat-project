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
    public partial class WizardOutsideHousePage : PhoneApplicationPage
    {
        public WizardOutsideHousePage()
        {
            InitializeComponent();
        }
        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            SettingsPageViewModel.SettingsPageInit();
            if (SettingsPageViewModel.IsPanoramaClickable)
            { 
                OutsideStaircase.Visibility = Visibility.Collapsed;
                Yard.Visibility = Visibility.Collapsed;
                Lift.Visibility = Visibility.Collapsed;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuestionsPage.DBSender = ((sender as Button).Name);
            NavigationService.Navigate(new Uri("/RoomPropertiesPage.xaml?sender=Outside", UriKind.Relative));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/WizardMainPage.xaml", UriKind.Relative));
        }

        private void Panorama_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (SettingsPageViewModel.IsPanoramaClickable)
            {
                string s = ((sender as PanoramaItem).Name);
                s = char.ToUpper(s[0]) + s.Substring(1);
                QuestionsPage.DBSender = s;
                NavigationService.Navigate(new Uri("/RoomPropertiesPage.xaml?sender=Inside", UriKind.Relative));
            }
        }

        private void SuperG(object sender, EventArgs e)
        {
            string msg = "במסך זה באפשרותך לבחור איזה אזור בסביבה החיצונית הקרובה לביתו של הקשיש אתה רוצה לבדוק";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}