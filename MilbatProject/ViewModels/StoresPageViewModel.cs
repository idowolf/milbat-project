using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MilbatProject.Resources;
using System.Xml.Linq;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using MilbatProject;
using System.Device.Location;


namespace MilbatProject.ViewModels
{
    public class StoresPageViewModel : INotifyPropertyChanged
    {
        private XDocument doc = XDocument.Load("StoresDatabase.xml");
        public ObservableCollection<StoreViewModel> StoresCollection { get; private set; }
        public ObservableCollection<CategoryViewModel> CategoryNames { get; private set; }
             
        public StoresPageViewModel()
        {
            this.StoresCollection = new ObservableCollection<StoreViewModel>();
            this.CategoryNames = new ObservableCollection<CategoryViewModel>();
            this.GetCategoryNames();
        }

        public void GetCategoryNames()
        {
            var data = from item in doc.Descendants("category")
                       select new CategoryViewModel
                       {	//other tags within the xml
                           LineOne = item.Attribute("ID").Value.ToString(),
                       };
            List<CategoryViewModel> lst = data.ToList();
            for (int i = 0; i < (lst.Count()); i++)
            {
                CategoryNames.Add(lst[i]);
            }
        }

        public void LoadData(int listSelection)
        {
            // Sample data; replace with real data
            var data = from item in doc.Descendants("store")
                       where (string)item.Parent.Attribute("ID") == CategoryNames[listSelection].LineOne
                       select new StoreViewModel
                       {	//other tags within the xml
                           LineOne = item.Parent.Attribute("ID").Value.ToString(),
                           LineTwo = item.Element("name").Value.ToString(),
                           Posx = double.Parse(item.Element("xpos").Value.ToString()),
                           Posy = double.Parse(item.Element("ypos").Value.ToString()),
                       };
            List<StoreViewModel> lst = data.ToList();
            for (int i = 0; i < (lst.Count()); i++)
            {
                this.StoresCollection.Add(lst[i]);
            }
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
        
        public string GetName(GeoCoordinate coordinate)
        {
            string res = "";
            for (int i = 0; i < StoresCollection.Count; i++)
			{
                int ax = (int)(StoresCollection[i].Posx * 1000);
                int ay = (int)(StoresCollection[i].Posy * 1000);
                int bx = (int)(coordinate.Latitude * 1000);
                int by = (int)(coordinate.Longitude * 1000);
                if (ax == bx && ay == by)
                    res = StoresCollection[i].LineTwo;
			}
            return res;
        }
    }
}
