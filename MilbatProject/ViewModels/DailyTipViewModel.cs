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

namespace MilbatProject.ViewModels
{
    public class DailyTipViewModel : INotifyPropertyChanged
    {
        Random rnd;
        public DailyTipViewModel()
        {
            this.TipsCollection = new ObservableCollection<TipViewModel>();
            rnd = new Random();
            this.LoadData();
        }
        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public ObservableCollection<TipViewModel> TipsCollection { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            // Sample data; replace with real data
            XDocument tipdoc = new XDocument();
            tipdoc = XDocument.Load("DailyTipDatabase.xml");
            var tipdata = from tip in tipdoc.Descendants("tip")
                       select new TipViewModel
                       {	//other tags within the xml
                           Key = tip.Element("key").Value.ToString(),
                           Question = tip.Element("question").Value.ToString(),
                           Detail = tip.Element("detail").Value.ToString(),
                           Link = tip.Element("link").Value.ToString(),
                       };
            List<TipViewModel> lst = tipdata.ToList();
            for (int i = 0; i < (lst.Count()); i++)
            {
                this.TipsCollection.Add(lst[i]);
            }
            this.IsDataLoaded = true;
        }

        public TipViewModel SelectRandomTip()
        {
            int index = rnd.Next(0, 17);
            return TipsCollection[index];
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
    }
}