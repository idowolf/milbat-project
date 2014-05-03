﻿using System;
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
using System.Xml;

namespace MilbatProject.ViewModels
{
    public class WizardResultsViewModel : INotifyPropertyChanged
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

        private List<XElement> _questions = new List<XElement>();

        public List<XElement> Questions
        {
            get { return _questions; }
            set { _questions = value; }
           
        }
        
        public void AddNewQuestion(string questionID)
        {
            _questions.Add(new XElement("record",
                new XAttribute("RecordID", questionID
                )));
        }
        
        public bool IsRoomExist(XDocument doc, string HouseName, string RoomName)
        {
            var RoomSelection = from room in doc.Descendants("room")
                       where (string)room.Parent.Attribute("HouseID") == HouseName
                       && (string)room.Attribute("RoomID") == RoomName
                       select room;
            if (RoomSelection.ToList().Count > 0)
                return true;
            return false;
        }

        public bool IsHouseExist(XDocument doc, string HouseName)
        {
            var HouseSelection = from house in doc.Descendants("room")
                                where (string)house.Attribute("HouseID") == HouseName
                                select house;
            if (HouseSelection.ToList().Count > 0)
                return true;
            return false;
        }

        public XDocument AddQueryToXML(XDocument doc)
        {
            if(IsHouseExist(doc, _houseID))
            {
                //Insert to existing room in existing house
                if(IsRoomExist(doc, _houseID, _roomName))
                {
                    foreach(XElement room in doc.Elements("room"))
                    {
                        if ((string)room.Attribute("RoomID") == _roomName)
                            room.Add(_questions);
                    }
                    return doc;
                }
                //Insert new room to existing house
                XElement elem = new XElement("room", _questions,
                    new XAttribute("RoomID", _roomName)
                    );
                foreach(XElement house in doc.Elements("house"))
                {
                    if ((string)house.Attribute("HouseID") == _houseID)
                        house.Add(elem);
                }
                return doc;
            }

            XElement newhouse = new XElement("house",
                    new XElement("room", _questions,
                    new XAttribute("RoomID", _roomName)),
                    new XAttribute("HouseID", _houseID));
            doc.Root.Add(newhouse);
            return doc;

        }

        public void InsertNewRoom()
        {
            XDocument doc = null;
            if(_houseID!="")
            { 
                InsertNewDataSet(doc); //Open and save the file, no changes made.
                ReadIsoStream(doc); //Display file again.
            }
        }

        public void InsertNewDataSet(XDocument doc)
        {
            using (IsolatedStorageFile isoStory = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("WizardResults.xml", FileMode.Open, isoStory))
                {
                    doc = XDocument.Load(isoStream,LoadOptions.PreserveWhitespace);
                    doc = AddQueryToXML(doc);
                    isoStream.Position = 0;
                    doc.Save(isoStream);
                }
            }
        }

        public void CreateNewFileIfNecessary()
        {
            XDocument doc = null;
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStore.FileExists("WizardResults.xml"))
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("WizardResults.xml", FileMode.Create, isoStore))
                    {
                        XDeclaration dec = new XDeclaration("1.0", "utf-8", "yes");
                        doc = new XDocument(dec, new XElement("houses"));
                        doc.Save(isoStream);
                    }
                }
            }
        }
        public void ReadIsoStream(XDocument doc)
        {
            using (IsolatedStorageFile isoStory = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("WizardResults.xml", FileMode.Open, isoStory))
                {
                    using (XmlReader reader = XmlReader.Create(isoStream))
                    {
                        XDocument xml = XDocument.Load(reader, LoadOptions.PreserveWhitespace);

                        MessageBox.Show(xml.ToString());
                    }
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
