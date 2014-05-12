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
    public partial class WizardMainPage : PhoneApplicationPage
    {
        public WizardMainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Wizard"+(sender as Button).Name+"HousePage.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void my_reports_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyReports.xaml", UriKind.Relative));
        }

        private void SuperG(object sender, EventArgs e)
        {
            string msg = "כאן ניתן לבחור את אזור הבדיקה – בתוך הבית או מחוצה לו, וגם לעיין בדוחות של הבתים והחדרים שכבר בדקת";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}