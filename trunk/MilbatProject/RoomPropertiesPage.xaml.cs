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

namespace MilbatProject
{
    public partial class RoomPropertiesPage : PhoneApplicationPage
    {
        public static string SelectedHouseID;
        public static string SelectedRoomName;
        private string selectedIndex = "";
        public RoomPropertiesPage()
        {
            InitializeComponent();
            DataContext = App.ResultsViewModel;
            App.ResultsViewModel.CreateNewFileIfNecessary();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationContext.QueryString.TryGetValue("sender", out selectedIndex);
        }
        private void Next_Click(object sender, EventArgs e)
        {
            if(DataValidation(name.Text, AppResources.ResidentEmpty) && DataValidation(room.Text,AppResources.RoomEmpty))
            { 
                App.ResultsViewModel.HouseID = name.Text;
                SelectedHouseID = name.Text;
                App.ResultsViewModel.RoomName = room.Text;
                SelectedRoomName = room.Text;
                NavigationService.Navigate(new Uri("/QuestionsPage.xaml", UriKind.Relative));
            }
            else
                MessageBox.Show("חובה להכניס את שם הבית והחדר!");
        }
        private void Back_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Wizard" + selectedIndex + "HousePage.xaml", UriKind.Relative));
        }

        private void name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name.Text.Equals("הקלד את שם הדייר כאן...", StringComparison.OrdinalIgnoreCase))
            {
                name.Text = string.Empty;
            }  
        }

        private void name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                name.Text = "הקלד את שם הדייר כאן...";
            }
        }

        private void room_GotFocus(object sender, RoutedEventArgs e)
        {
            if (room.Text.Equals("הקלד את שם החדר כאן...", StringComparison.OrdinalIgnoreCase))
            {
                room.Text = string.Empty;
            }  
        }

        private void room_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(room.Text))
            {
                room.Text = "הקלד את שם החדר כאן...";
            }
        }

        public static bool DataValidation(string toTest, string EmptyString)
        {
            return toTest != EmptyString && toTest != "";
        }
        private void SuperG(object sender, EventArgs e)
        {
            string msg = " כדי שתוכל לבדוק מספר בתים, וכדי שתדע לזהות את החדר שבדקת, אנא מלא את הפרטים בתיבות.";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}