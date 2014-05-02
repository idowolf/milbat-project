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
using System.IO.IsolatedStorage;
using System.IO;

namespace MilbatProject.ViewModels
{
    class WizardResultsViewModel : INotifyPropertyChanged
    {
        private string _houseID;

        public string HouseID
        {
            get { return _houseID; }
            set { _houseID = value; }
        }

        private string _roomName;

        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        private List<string> _questionIDs;

        public List<string> QuestionIDs
        {
            get { return _questionIDs; }
            set { _questionIDs = value; }
        }
        

        public void InsertNewRoom()
        {
            XDocument doc = null;
                
                XElement addition = new XElement("houses",
                    new XElement("house",
                new XAttribute("HouseID", "הבית_של_פיסטוק"),
                new XElement("room",
                    new XAttribute("RoomID", "חדר_מחשב"),
                    new XElement("record",
                        new XAttribute("RecordID", "01.01.01")
                        )
                    )
                )
                );

                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    isoStore.Remove();
                    if (!isoStore.FileExists("WizardResults.xml"))
                    {
                        using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("WizardResults.xml", FileMode.Create, isoStore))
                        {

                            doc = new XDocument(new XElement("houses"));
                            doc.Element("houses").Add(addition.Element("house"));
                            doc.Save(isoStream);
                            //doc = XDocument.Load(isoStream);
                            //ReadIsoStream(doc);
                            doc = XDocument.Load(isoStream);
                            //doc.Element("houses").Add(addition.Element("house"));
                            var b = from room in doc.Descendants("room")
                                    where room.Parent.Attribute("HouseID").ToString() == "הבית_של_פיסטוק"
                                    select room;
                        }
                    }
                }
                using (IsolatedStorageFile isoStory = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("WizardResults.xml", FileMode.Open, isoStory))
                    {
                        doc.Save(isoStream);
                        ReadIsoStream(doc);
                    }
                }
        }

        public void ReadIsoStream(XDocument Doc)
        {
            MessageBox.Show(Doc.ToString());
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
