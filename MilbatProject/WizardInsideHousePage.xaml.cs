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
    public partial class WizardInsideHousePage : PhoneApplicationPage
    {
        //public string[] RoomNames = { "Door", "Hallway", "Livingroom", "Kitchen", "Bathtub", "Shower",
          //                                       "Restroom", "Bedroom", "Misc", "InsideStaircase", "OutsideStaircase", 
            //                                     "Yard", "Lift" };
        public WizardInsideHousePage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            SettingsPageViewModel.SettingsPageInit();
            if (SettingsPageViewModel.IsPanoramaClickable)
            {
                Door.Visibility = Visibility.Collapsed;
                Bathtub.Visibility = Visibility.Collapsed;
                Hallway.Visibility = Visibility.Collapsed;
                Livingroom.Visibility = Visibility.Collapsed;
                Kitchen.Visibility = Visibility.Collapsed;
                Shower.Visibility = Visibility.Collapsed;
                Restroom.Visibility = Visibility.Collapsed;
                Bedroom.Visibility = Visibility.Collapsed;
                Misc.Visibility = Visibility.Collapsed;
                InsideStaircase.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuestionsPage.DBSender = ((sender as Button).Name);
            NavigationService.Navigate(new Uri("/RoomPropertiesPage.xaml?sender=Inside", UriKind.Relative));
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
            string msg = "במסך זה באפשרותך לבחור איזה אזור בתוך הבית אתה רוצה לבדוק";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}