﻿using System;
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
    public partial class MyReports : PhoneApplicationPage
    {
        private static MyReportsViewModel suggestions;
        
        public static MyReportsViewModel Suggestions
        {
            get { return suggestions; }
            set { suggestions = value; }
        }
        
        
        public MyReports()
        {
            InitializeComponent();
        }



        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/MyReportsInsideHouse.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as House).ID, UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        private void ForceNewFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("האם אתה בטוח שברצונך למחוק את הדוחות שלך?","אזהרה!",MessageBoxButton.OKCancel);
            if (MessageBoxResult.OK.ToString() == "OK")
            {
                WizardResultsViewModel.ForceNewFile();
                NavigationService.Navigate(new Uri("/WizardMainPage.xaml", UriKind.Relative));

            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            App.AllQuestionsViewModel.LoadData();
            suggestions = new MyReportsViewModel();
            App.AllQuestionsViewModel = new WizardViewModel();
            App.AllQuestionsViewModel.LoadData();
            suggestions.LoadData(App.AllQuestionsViewModel);
            DataContext = suggestions;
        }
    }
}