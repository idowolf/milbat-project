using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;
using MilbatProject.ViewModels;


namespace MilbatProject
{
    public partial class DidYouKnowPage : PhoneApplicationPage
    {

        public DidYouKnowPage()
        {
            InitializeComponent();
            DataContext = App.Tips.SelectRandomTip();
            GetNewTip();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        public async void GetNewTip()
        {
            await Task.Delay(TimeSpan.FromSeconds(15));
            DataContext = App.Tips.SelectRandomTip();
            GetNewTip();
        }

        private void SuperG(object sender, EventArgs e)
        {
            string msg = "אז הנה הטיפ היומי, טיפ המכיל מידע על אביזרים שונים שיעזרו לחברינו מהגיל השלישי לתפקד טוב יותר, ואפילו אפשרות לרכוש אותם באינטרנט. שימו לב כי אין אפשרות לשנות את הטיפ ידנית, הוא משתנה אוטומטית אחת ליום.";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}