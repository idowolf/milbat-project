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
using System.Xml.Linq;

namespace MilbatProject
{
    public partial class QuestionsPage : PhoneApplicationPage
    {
        private static WizardViewModel dB = null;
        private static string dBSender;
        private int questionResult;

        public static string DBSender
        {
            get { return dBSender; }
            set { dBSender = value; }
        }
        
        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>
        public static WizardViewModel DB
        {
            get
            {
                // Delay creation of the view model until necessary
                if (dB == null)
                    dB = new WizardViewModel();

                return dB;
            }
        }
        string selectedIndex = "";
        // Constructor
        public QuestionsPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private int y = 0;

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            questionResult = 0;
            if (DataContext == null)
            {
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    y = Array.IndexOf(dB.ItemIDs, selectedIndex);
                        //.[dB.ItemIDs[index]];
                }
                else
                {
                    dB = new WizardViewModel();
                    dB.LoadData(DBSender);
                }
            }
            if (y == 0)
                (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = false;
            else
                (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = true;
            if (y == dB.QuestionsCollection.Count() - 1)
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
                (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = true;
            }
            else
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = true;
                (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = false;
            }
            DataContext = dB.QuestionsCollection[y];
        }



        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            if(questionResult == 0)
                App.ResultsViewModel.AddNewQuestion(dB.QuestionsCollection[y].ID);
            //if (Array.IndexOf(dB.ItemIDs, selectedIndex) < (dB.QuestionsCollection.Count() - 1))
            if(y < dB.QuestionsCollection.Count() - 1)
            {
                //NavigationService.Navigate(new Uri("/QuestionsPage.xaml?selectedItem=" + dB.QuestionsCollection[Array.IndexOf(dB.ItemIDs, selectedIndex) + 1].ID, UriKind.Relative));
                NavigationService.Navigate(new Uri("/QuestionsPage.xaml?selectedItem=" + dB.QuestionsCollection[y + 1].ID, UriKind.Relative));
                int x = Array.IndexOf(dB.ItemIDs, selectedIndex) + 1;
            }
        }

        private void Previousbutton_Click(object sender, EventArgs e)
        {
            //if (Array.IndexOf(dB.ItemIDs, selectedIndex) > 0)
            if (y > 0)
            {
                //NavigationService.Navigate(new Uri("/QuestionsPage.xaml?selectedItem=" + dB.QuestionsCollection[Array.IndexOf(dB.ItemIDs, selectedIndex) - 1].ID, UriKind.Relative));
                NavigationService.Navigate(new Uri("/QuestionsPage.xaml?selectedItem=" + dB.QuestionsCollection[y - 1].ID, UriKind.Relative));
                int x = Array.IndexOf(dB.ItemIDs, selectedIndex) + 1;
            }
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            questionResult = 1;
        }

        private void takin_helkit_Click(object sender, RoutedEventArgs e)
        {
            questionResult = 0;
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            questionResult = 0;
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            if (questionResult == 0)
                App.ResultsViewModel.AddNewQuestion(dB.QuestionsCollection[y].ID);
            App.ResultsViewModel.InsertNewRoom();
            App.ResultsViewModel = null;
            MessageBox.Show("התשובות נקלטו בהצלחה!");
            NavigationService.Navigate(new Uri("/WizardMainPage.xaml", UriKind.Relative));
        }
    }
}