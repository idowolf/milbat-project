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
        public RoomPropertiesPage()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/QuestionsPage.xaml", UriKind.Relative));
        }
    }
}