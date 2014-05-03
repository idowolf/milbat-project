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
            NavigationService.Navigate(new Uri("/WizardMainPage.xaml", UriKind.Relative));
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
            NavigationService.Navigate(new Uri("/StoresPage.xaml", UriKind.Relative));
        }

        private void takanon_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DisclaimerPage.xaml", UriKind.Relative));
        }

        private void tzilom_dayar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PictureResidentPage.xaml", UriKind.Relative));
        }
        //    // Set the data context of the LongListSelector control to the sample data

        //    DataContext = App.ViewModel;
        //}

        //// Load data for the ViewModel QuestionsCollection
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //}

        //// Handle selection changed on LongListSelector
        //private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // If selected item is null (no selection) do nothing
        //    if (MainLongListSelector.SelectedItem == null)
        //        return;

        //    // Navigate to the new page
        //    NavigationService.Navigate(App.ViewModel.GetNavigationContext(MainLongListSelector.SelectedItem as MainPageListViewModel));
        //    MainLongListSelector.SelectedItem = null;
        //}

        ////void GotoWizardPage_Click(object sender, EventArgs e)
        ////{
        ////    NavigationService.Navigate(new Uri("/WizardPage.xaml", UriKind.Relative));
        ////}

        ////void appBarButton_Click(object sender, EventArgs e)
        ////{
        ////    Application.Current.Terminate();
        ////}


        ////void ReturntoMainPage_Click(object sender, EventArgs e)
        ////{
        ////    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        ////}

    }
}