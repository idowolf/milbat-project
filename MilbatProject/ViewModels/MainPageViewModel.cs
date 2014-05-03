using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MilbatProject.Resources;
using System.Xml.Linq;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace MilbatProject.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
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