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
        bool disclaimerSigned = false;
        public DisclaimerPage()
        {
            InitializeComponent();
            disclaimerSigned = DisclaimerPageViewModel.IsDisclaimerSigned();
        }

        private void UserDisclaimerSign_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (disclaimerSigned)
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
                if (!disclaimerSigned)
                {
                    UserDisclaimerSign.IsChecked = true;
                    DisclaimerPageViewModel.SignDisclaimer();
                    MessageBox.Show("תודה על אישור התקנון.\n כעת תועבר לאשף ההגדרות.");
                    NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));

                }
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            if (disclaimerSigned)
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            else
                MessageBox.Show("חובה לחתום על התקנון לפני שתוכל להמשיך.");
        }

        private void SuperG(object sender, EventArgs e)
        {
            string msg = "";
            if (!disclaimerSigned)
                msg += "עליכם לאשר את התקנון כדי לעבור לשימוש באפליקציה. שימו לב כי אין אפשרות להשתמש באפליקציה ללא אישור התקנון! אישור התקנון מתבצע על-ידי לחיצה על תיבת-הסימון בסוף התקנון, ולאחר מכן לחיצה על העיגול השמאלי המצויר בדיסק.";
            else
                msg += "כאן תוכלו לראות את תקנון השימוש באפליקציה";

            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}