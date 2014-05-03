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
    public partial class WizardOutsideHousePage : PhoneApplicationPage
    {
        public WizardOutsideHousePage()
        {
            InitializeComponent();
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
    }
}