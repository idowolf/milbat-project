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
            if(name.Text!="" && room.Text!="")
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
    }
}