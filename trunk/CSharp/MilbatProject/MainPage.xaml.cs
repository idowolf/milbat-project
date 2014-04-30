﻿using System;
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
            // Set the data context of the LongListSelector control to the sample data

            DataContext = App.ViewModel;
            // Sample code to localize the ApplicationBar
        }

        // Load data for the ViewModel QuestionsCollection
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            //App.ViewModel.QuestionsCollection[Array.IndexOf(App.ViewModel.ItemIDs, selectedIndex)+1].ID
            //NavigationService.Navigate(new Uri("/WizardPage.xaml?selectedItem=" + DetailsPage.DB.QuestionsCollection[0].ID, UriKind.Relative));
            int selectedIndex = App.ViewModel.Items.IndexOf(MainLongListSelector.SelectedItem as MainPageListViewModel);
            NavigationService.Navigate(new Uri("/" + PageSelection[selectedIndex] + ".xaml", UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        //void GotoWizardPage_Click(object sender, EventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/WizardPage.xaml", UriKind.Relative));
        //}

        //void appBarButton_Click(object sender, EventArgs e)
        //{
        //    Application.Current.Terminate();
        //}


        //void ReturntoMainPage_Click(object sender, EventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        //}

        public readonly string[] PageSelection = { "WizardPage", "WizardPage", "WizardPage" };
    }
}