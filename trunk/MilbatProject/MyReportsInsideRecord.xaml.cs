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
    public partial class MyReportsInsideRecord : PhoneApplicationPage
    {
        private string selectedHouse = "", selectedRoom = "", selectedQuestion = "";
        private int houseIndex = 0, roomIndex = 0, questionIndex = 0;
        public MyReportsInsideRecord()
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
                    roomIndex = int.Parse(selectedRoom);
                if (NavigationContext.QueryString.TryGetValue("selectedQuestion", out selectedQuestion))
                    questionIndex = int.Parse(selectedQuestion);
                DataContext = MyReports.Suggestions.Houses[houseIndex].HouseRooms[roomIndex].RoomRecords[questionIndex];
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyReportsInsideRoom.xaml?selectedHouse=" + selectedHouse + "&selectedRoom=" + selectedRoom, UriKind.Relative));

        }
    }
}