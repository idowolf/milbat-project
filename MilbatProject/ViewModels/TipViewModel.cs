using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml.Linq;
using System.Text;
using System.Linq;

namespace MilbatProject.ViewModels
{
    public class TipViewModel : INotifyPropertyChanged
    {
        private string key;

        public string Key
        {
            get { return key; }
            set
            {
                if (value != key)
                {
                    key = value;
                    this.ImageUri = "/Assets/DailyTips/" + key + ".jpg";
                    NotifyPropertyChanged("Key");
                }
            }
        }
        private string question;

        public string Question
        {
            get { return question; }
            set
            {
                if (value != question)
                {
                    question = value;
                    NotifyPropertyChanged("Question");
                }
            }
        }

        private string detail;

        public string Detail
        {
            get { return detail; }
            set
            {
                if (value != detail)
                {
                    detail = value;
                    NotifyPropertyChanged("Detail");
                }
            }
        }

        private string link;

        public string Link
        {
            get { return link; }
            set
            {
                if (value != link)
                {
                    link = value;
                    NotifyPropertyChanged("Link");
                }
            }
        }

        private string imageUri;

        public string ImageUri
        {
            get { return imageUri; }
            set
            {
                if (value != imageUri)
                {
                    imageUri = value;
                    NotifyPropertyChanged("ImageUri");
                }
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
    }
}
