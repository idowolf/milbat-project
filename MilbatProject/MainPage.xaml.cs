using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MilbatProject.Resources;
using MilbatProject.ViewModels;
using MilbatProject;
using Microsoft.Phone.Tasks;
using System.Device.Location;
using System.Windows.Media.Imaging;

namespace MilbatProject
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
        }

        private void ashaf_Click(object sender, RoutedEventArgs e)
        {
            //BingMapsTask bingMapsTask = new BingMapsTask();

            ////Omit the Center property to use the user's current location.
            //bingMapsTask.Center = new GeoCoordinate(47.6204, -122.3493);

            //bingMapsTask.SearchTerm = "coffee";
            //bingMapsTask.ZoomLevel = 2;

            //bingMapsTask.Show();
            NavigationService.Navigate(new Uri("/WizardMainPage.xaml", UriKind.Relative));
            //NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
            //MessageBox.Show(DateTime.Now.Day.ToString());
        }

        private void did_you_know_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DidYouKnowPage.xaml", UriKind.Relative));
        }

        private void odot_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void contact_us_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ContactPage.xaml", UriKind.Relative));
        }

        private void hanoyot_ve_avizarim_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/StoresMainPage.xaml", UriKind.Relative));
        }

        private void takanon_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DisclaimerPage.xaml", UriKind.Relative));
        }

        private void tzilom_dayar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PictureResidentPage.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Check if ExtendedSplashscreen.xaml is on the backstack  and remove 
            if (NavigationService.BackStack.Count() == 1)
            {
                NavigationService.RemoveBackEntry();
            }

        }


        private void Settings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        private void SuperG(object sender, EventArgs e)
        {
            string msg = "שלום לכם, וברוכים הבאים לאפליקציית '. באפליקציה זו תוכלו לבצע בדיקת בטיחות לביתכם מפני גורמים המהווים סכנה עבור קשישים, לקבל טיפים לבטיחות הבית באמצעות אביזרים שונים, לאתר חנויות המספקות אביזרים בקרבת מקום, לצלם תמונות, וליצור עמנו קשר. אני אלווה אתכם לאורך כל האפליקציה. לשם הפעלתי, תוכלו ללחוץ על כפתור ה-S בתחתית הדף, ואופיע מיד להסביר לכם את אופן השימוש במסך הנוכחי, רק כדי לשמור על בטיחותכם. מאחל לכם שימוש מהנה ונכון באפליקציה, ובעיקר בטוח, סופר-סבא!";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}