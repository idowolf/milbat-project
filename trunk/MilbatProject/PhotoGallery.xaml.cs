using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using MilbatProject.Resources;
using System.IO.IsolatedStorage;
using System.Windows.Media;

namespace MilbatProject
{
    public partial class PhotoGallery : PhoneApplicationPage
    {
        private int firstImage, pointer;
        private string selectedIndex = "";
        List<string> picturefileNames = new List<string>();
        List<BitmapImage> RetrievedImages = new List<BitmapImage>();

        public PhotoGallery()
        {
            InitializeComponent();
        }

        public void FindAllImages()
        {
            List<Uri> cycleImages = new List<Uri>();
            int kon = 0;
            using (var isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                List<string> fileNames = isoStore.GetFileNames().ToList();
                for (int i = 0; i < fileNames.Count; i++)
                {
                    if (fileNames[i].Contains(".jpg"))
                        picturefileNames.Add(fileNames[i]);

                }
                for (int i = 0; i < picturefileNames.Count; i++)
                {
                    if (kon < 9 && kon < picturefileNames.Count)
                    {
                        cycleImages.Add(new Uri("isostore:/Shared/ShellContent/"+ picturefileNames[kon], UriKind.Absolute));
                        kon++;
                    }
                    using (var isoFileStream = isoStore.OpenFile(picturefileNames[i], System.IO.FileMode.Open))
                    {
                        BitmapImage tmp = new BitmapImage();
                        tmp.SetSource(isoFileStream);
                        RetrievedImages.Add(tmp);
                    }
                }
            }
            int cnt = Math.Min(cycleImages.Count, kon);
            if (picturefileNames.Count > 0)
            {
                ShellTile myTile = ShellTile.ActiveTiles.First();
                CycleTileData cycleTile = new CycleTileData()
                {
                    Title = "משמרת הזהב",
                    Count = cnt,
                    SmallBackgroundImage = new Uri("/Assets/Tiles/IconicTileSmall.png", UriKind.Relative),
                    CycleImages = cycleImages.ToArray(),
                };
                myTile.Update(cycleTile);
            }

            //for (int i = 0; i < RetrievedImages.Count; i++)
            for (int i = firstImage, k=0; i < RetrievedImages.Count && k < 9; i++, k++)
            {
                Thickness[] layout = new Thickness[]{
                    new Thickness(310,-300,0,0),
                    new Thickness(155,-300,155,0),
                    new Thickness(0,-300,310,0),
                    new Thickness(310,0,0,0),
                    new Thickness(155,0,155,0),
                    new Thickness(0,0,310,0),
                    new Thickness(310,300,0,0),
                    new Thickness(155,300,155,0),
                    new Thickness(0,300,310,0)};
                Image img = new Image();
                img.Margin = layout[k];
                img.Height = 100;
                img.Source = RetrievedImages[i];
                ContentPanel.Children.Add(img);
                TextBlock picname = new TextBlock();
                picname.Text = picturefileNames[i].Substring(0,picturefileNames[i].IndexOf(".jpg"));
                picname.Foreground = new SolidColorBrush(Colors.Black);
                picname.Margin = new Thickness(layout[k].Left + 40, layout[k].Top + 150, layout[k].Right, layout[k].Bottom);
                picname.Height = 30;
                ContentPanel.Children.Add(picname);
                pointer = i;

            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    firstImage = int.Parse(selectedIndex);
                }
                else
                {
                    firstImage = 0;
                }
            }
            FindAllImages();
        }

        private void NextPage(object sender, EventArgs e)
        {
            if (pointer == 8 && RetrievedImages.Count > pointer + firstImage)
            {
                int indicator = pointer + firstImage + 1;
                NavigationService.Navigate(new Uri("/PhotoGallery.xaml?selectedItem=" + indicator, UriKind.Relative));
            }
        }

        private void BackPage(object sender, EventArgs e)
        {
            if(firstImage!=0)
                NavigationService.Navigate(new Uri("/PhotoGallery.xaml?selectedItem=" + (firstImage - 9), UriKind.Relative));
            else
                NavigationService.Navigate(new Uri("/PictureResidentPage.xaml", UriKind.Relative));
        }
    }
}