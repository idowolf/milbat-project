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
using System.Windows.Media.Imaging;
using MilbatProject.Resources;
using System.IO.IsolatedStorage;

namespace MilbatProject
{
    public partial class PictureResidentPage : PhoneApplicationPage
    {

        CameraCaptureTask _cameraTask;
        BitmapImage _imageToBeSaved;
        public PictureResidentPage()
        {
            InitializeComponent();
            _cameraTask = new CameraCaptureTask();
            _cameraTask.Completed += _cameraTask_Completed;
            (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = false; 
        }

        private void Return_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }


        private void button_capture_Click(object sender, RoutedEventArgs e)
        {
            _cameraTask.Show();
        }

        void _cameraTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
                (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = true; 
                BeforePicture.Visibility = Visibility.Collapsed;
                AfterPicture.Visibility = Visibility.Visible;
                _imageToBeSaved = new BitmapImage();
                _imageToBeSaved.SetSource(e.ChosenPhoto);
                image_result.Source = _imageToBeSaved;
            }
        }

        private void SaveImage(object sender, EventArgs e)
        {
            if (!DataValidation(name.Text, AppResources.ResidentEmpty))
                MessageBox.Show("חובה להכניס שם דייר!");
            else
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    var wb = new WriteableBitmap(_imageToBeSaved);
                    using (var isoFileStream = isoStore.CreateFile(name.Text + ".jpg"))
                        Extensions.SaveJpeg(wb, isoFileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                    using (var isoFileStream = isoStore.CreateFile("/Shared/ShellContent/" + name.Text + ".jpg"))
                        Extensions.SaveJpeg(wb, isoFileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                    MessageBox.Show("התמונה נשמרה בהצלחה");
                    NavigationService.Navigate(new Uri("/PhotoGallery.xaml", UriKind.Relative));
                }
            }
        }

        private void name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name.Text.Equals("הקלד את שם הדייר כאן...", StringComparison.OrdinalIgnoreCase))
            {
                name.Text = string.Empty;
            }
        }

        private void name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                name.Text = "הקלד את שם הדייר כאן...";
            }
        }
        public static bool DataValidation(string toTest, string EmptyString)
        {
            return toTest != EmptyString && toTest != "";
        }

        private void Gallery_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PhotoGallery.xaml", UriKind.Relative));

        }

        private void BackPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}