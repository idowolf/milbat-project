using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using MilbatProject.ViewModels;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MilbatProject.Resources;
using MilbatProject.ViewModels;

namespace MilbatProject
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        bool clickFlag = false;
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void TogglePanorama_Click(object sender, RoutedEventArgs e)
        {
            AlternatePanoramaFlag();
        }

        private void AlternatePanoramaFlag()
        {
            if (!clickFlag)
            {
                SetBrush("Assets/ToggleButtonPanorama.png");
                clickFlag = true;
            }
            else
            {
                SetBrush("Assets/ToggleButtonEnable.png");
                clickFlag = false;
            }
        }

        private void SetBrush(string UriAddress)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(UriAddress, UriKind.Relative));
            TogglePanorama.Background = brush;
        }

        private void userName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userName.Text.Equals(AppResources.userNameEmpty, StringComparison.OrdinalIgnoreCase))
            {
                userName.Text = string.Empty;
            }
        }

        private void userName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(userName.Text))
            {
                userName.Text = AppResources.userNameEmpty;
            }
        }

        private void emailAddress_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailAddress.Text.Equals(AppResources.eMailEmpty, StringComparison.OrdinalIgnoreCase))
            {
                emailAddress.Text = string.Empty;
            }
        }

        private void emailAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(emailAddress.Text))
            {
                emailAddress.Text = AppResources.eMailEmpty;
            }
        }

        private void IncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            SettingsPageViewModel.PreviewNewFont(2,this.LayoutRoot);
        }

        private void DecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            SettingsPageViewModel.PreviewNewFont(-2,this.LayoutRoot);
        }

        private void SaveChanges(object sender, EventArgs e)
        {
            bool checkuserName = userName.Text == null || userName.Text == AppResources.userNameEmpty;
            bool checkeMail = emailAddress.Text == null || emailAddress.Text == AppResources.eMailEmpty;
            if (checkuserName || checkeMail)
                MessageBox.Show("הנך חייב להזין שם משתמש וכתובת דואר אלקטרוני!");
            else
            {
                SettingsPageViewModel.ApplyAndSaveChanges(userName.Text, emailAddress.Text, clickFlag);
                MessageBox.Show("השינויים נשמרו בהצלחה.");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            SettingsPageViewModel.ResizeFontPage(this.LayoutRoot, SettingsPageViewModel.FontOffset);
            clickFlag = SettingsPageViewModel.IsPanoramaClickable;
            if (clickFlag)
                SetBrush("Assets/ToggleButtonPanorama.png");
            if (SettingsPageViewModel.UserName != "")
                userName.Text = SettingsPageViewModel.UserName;
            if (SettingsPageViewModel.eMail != "")
                emailAddress.Text = SettingsPageViewModel.eMail;
        }

        private void Return(object sender, EventArgs e)
        {
            if (SettingsPageViewModel.UserName == "" || SettingsPageViewModel.eMail == "")
                MessageBox.Show("הנך חייב להזין שם משתמש וכתובת דואר אלקטרוני בהפעלה הראשונה.");
            else
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }

        private void SuperG(object sender, EventArgs e)
        {
            string msg = "במסך זה תוכלו להגדיר את שמך ואת המייל שלך, לצורך משלוח הדוח שיופק לך בשלב מאוחר יותר, בנוסף לכך, תוכל לבחור את האופן דרכו תוכל להיכנס לאשף. תוכל להגדיל את הפונט על ידי לחיצה על כפתור 'הגדל פונט' או להקטין אותו על ידי לחיצה על כפתור 'הקטן פונט'. לא לשכוח ללחוץ על 'שמור' (העיגול עם סימן שמור בתחתית הדף) כדי שהנתונים יישמרו.";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}