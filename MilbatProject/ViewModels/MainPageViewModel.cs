using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MilbatProject.Resources;
using System.Xml.Linq;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;

namespace MilbatProject.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        async public static void RescueMe(Grid LayoutRoot, Grid TitlePanel, Grid ContentPanel, string SuperMessage)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("Assets/superG.png", UriKind.RelativeOrAbsolute));
            img.Margin = new Thickness(0, 300, 0, 0);
            TitlePanel.Visibility = Visibility.Collapsed;
            ContentPanel.Visibility = Visibility.Collapsed;
            LayoutRoot.Children.Add(img);
            await Task.Delay(TimeSpan.FromSeconds(0.1)); // set your desired delay
            MessageBox.Show(SuperMessage);
            TitlePanel.Visibility = Visibility.Visible;
            ContentPanel.Visibility = Visibility.Visible;
            LayoutRoot.Children.Remove(img);
        }
        public ObservableCollection<MainPageListViewModel> Items { get; private set; }
        public MainPageViewModel()
        {
            this.Items = new ObservableCollection<MainPageListViewModel>();
            LoadMenuList();
        }
        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public void LoadMenuList()
        {
            this.Items.Add(new MainPageListViewModel() { ID = "0", LineOne = "אשף הבטיחות", LineTwo = "", LineThree = "" });
            this.Items.Add(new MainPageListViewModel() { ID = "1", LineOne = "מסך צילום", LineTwo = "", LineThree = "" });
            this.Items.Add(new MainPageListViewModel() { ID = "2", LineOne = "הידעת?", LineTwo = "", LineThree = "" });
            this.Items.Add(new MainPageListViewModel() { ID = "3", LineOne = "אודות העמותה", LineTwo = "", LineThree = "" });
            this.Items.Add(new MainPageListViewModel() { ID = "4", LineOne = "צור קשר", LineTwo = "", LineThree = "" });
            this.Items.Add(new MainPageListViewModel() { ID = "5", LineOne = "תקנון משפטי", LineTwo = "", LineThree = "" });

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string[] PageSelection = { "WizardMainPage", "MainPage" };
        public Uri GetNavigationContext(MainPageListViewModel nextItem)
        {
            return new Uri("/" + PageSelection[Items.IndexOf(nextItem)] + ".xaml", UriKind.Relative);
        }
    }
}