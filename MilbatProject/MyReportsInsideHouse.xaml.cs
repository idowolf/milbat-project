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
    public partial class MyReportsInsideHouse : PhoneApplicationPage
    {
        private string selectedIndex = "";
        public MyReportsInsideHouse()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    MyReports.Suggestions.Houses[index].LineTwo = "Assets/SafetyMeasure" + MyReports.Suggestions.CalculateSafetyScale(MyReports.Suggestions.Houses[index].LineOne) + ".png";
                    DataContext = MyReports.Suggestions.Houses[index];

                }
            }
        }


        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/MyReportsInsideRoom.xaml?selectedHouse=" + selectedIndex + "&selectedRoom=" + (MainLongListSelector.SelectedItem as Room).ID, UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MyReports.xaml", UriKind.Relative));

        }
        private void SuperG(object sender, EventArgs e)
        {
            string msg = "כאן נראה את כל האזורים בבית בהם ערכנו את אשף הבטיחות, ואת מד הבטיחות המציג לנו את הרמה הממוצעת של בטיחות הבית בעבור קשישים. בלחיצה על שם האזור תוכלו לראות את הדברים שנחשבים למסוכנים באותו אזור, כך שתוכלו לתקנם.\nניתן לחזור בכל עת למסך זה או למסך האחרון בו ביקרתם על ידי לחיצה על הכפתור 'חזור' (החץ התחתון הפונה לצד שמאל). ";
            MainPageViewModel.RescueMe(LayoutRoot, TitlePanel, ContentPanel, msg);
        }
    }
}