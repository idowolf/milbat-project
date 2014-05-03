using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuestionsPage.DBSender = ((sender as Button).Name);
            NavigationService.Navigate(new Uri("/RoomPropertiesPage.xaml?sender=Inside", UriKind.Relative));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/WizardMainPage.xaml", UriKind.Relative));
        }
    }
}