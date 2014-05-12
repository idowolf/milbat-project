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
    public partial class StoresMainPage : PhoneApplicationPage
    {
        private static StoresPageViewModel vM;

        public static StoresPageViewModel VM
        {
            get { return vM; }
            set { vM = value; }
        }
        
        public StoresMainPage()
        {
            InitializeComponent();
            vM = new StoresPageViewModel();
            DataContext = vM;
        }

        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            int selectedIndex = MainLongListSelector.ItemsSource.IndexOf(MainLongListSelector.SelectedItem as CategoryViewModel);
            vM.LoadData(selectedIndex);
            NavigationService.Navigate(new Uri("/StoresPage.xaml", UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        private void ReturnHome(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void SuperG(object sender, EventArgs e)
        {
            string msg = "כאן תוכלו למצוא את החנויות הקרובות ביותר לביתכם המוכרות מגוון אביזרי עזר לבטיחות הבית עבור קשישים. תוכלו לחפש חנות באמצעות בחירה של אחת הקטגוריות והקשה על החיצים שיופיעו על המפה.";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}