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
    public partial class ContactPage : PhoneApplicationPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Mail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("לא ניתן כעת. \n עמנו הסליחה.");
        }

        private void Call_Click(object sender, EventArgs e)
        {
            MessageBox.Show("לא ניתן כעת. \n עמנו הסליחה.");
        }
    }
}