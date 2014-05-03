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
    public partial class MyReportsInsideRoom : PhoneApplicationPage
    {
        private string selectedHouse = "", selectedRoom = "";
        private int houseIndex = 0, roomIndex = 0;
        public MyReportsInsideRoom()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                if (NavigationContext.QueryString.TryGetValue("selectedHouse", out selectedHouse))
                    houseIndex = int.Parse(selectedHouse);
                if (NavigationContext.QueryString.TryGetValue("selectedRoom", out selectedRoom))
                {
                    roomIndex = int.Parse(selectedRoom);
                }
                DataContext = MyReports.Suggestions.Houses[houseIndex].HouseRooms[roomIndex];
            }
        }


        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/MyReportsInsideRecord.xaml?selectedHouse=" + selectedHouse
                + "&selectedRoom=" + selectedRoom + "&selectedQuestion=" +
                MyReports.Suggestions.Houses[houseIndex].HouseRooms[roomIndex].RoomRecords.IndexOf((MainLongListSelector.SelectedItem as SuggestionsViewModel)), UriKind.Relative));
            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }
    }
}