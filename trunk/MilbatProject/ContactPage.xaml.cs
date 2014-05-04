using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using MilbatProject.ViewModels;

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
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "milbat@netvision.net.il";
            emailComposeTask.Subject = "הודעה שנשלחה מתוך 'משמרת הזהב'";
            emailComposeTask.Body = "";
            emailComposeTask.Body += "משתמש יקר, \nאנא צרף הודעתך מטה:\n\n\n";
            MessageBoxResult m = MessageBox.Show("האם ברצונך לצרף את הדוחות שלך לצורך בקרה ושיפור היישומון?", "בקשה לשליחת הנתונים", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {
                emailComposeTask.Body += "דוח המשתמש:\n";
                emailComposeTask.Body += "דרוש שיפור לשאלות במספרים הסידוריים הבאים:\n";
                emailComposeTask.Body += WizardResultsViewModel.GetUserReports();
            }
            emailComposeTask.Show();
        }

        private void Call_Click(object sender, EventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            phoneCallTask.PhoneNumber = "0722230007";
            phoneCallTask.DisplayName = "עמותת מילבת";
            phoneCallTask.Show();
        }
    }
}