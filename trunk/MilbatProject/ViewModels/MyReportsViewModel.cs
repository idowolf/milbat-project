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
using System.Xml;


namespace MilbatProject.ViewModels
{
    public class MyReportsViewModel : INotifyPropertyChanged
    {
        private XDocument doc = XDocument.Load("MilbatDatabase.xml");
        public MyReportsViewModel()
        {
            this.SuggestionsCollection = new ObservableCollection<SuggestionsViewModel>();
        }

        private List<House> _houses = new List<House>();

        public List<House> Houses
        {
            get { return _houses; }
            set { _houses = value; }
        }

        //public void AddCollectionToStructure()
        //{
        //    if (SuggestionsCollection.Count() == 0)
        //    {

        //    }
        //    else 
        //    {
        //        int housesCount = 0;
        //        int roomsCount = 0;
        //        bool roomChanged = false, houseChanged = false, execflag = false;
        //        _houses.Add(new House(housesCount, SuggestionsCollection[0].ID));
        //        Room newRoom = new Room(roomsCount, SuggestionsCollection[0].LineOne);
        //        //newRoom.RoomRecords.Add(SuggestionsCollection[0]);
        //        for (int i = 0; i < SuggestionsCollection.Count(); i++)
        //        {
        //            if(SuggestionsCollection[i].ID == _houses[housesCount].LineOne)
        //            {
        //                if(SuggestionsCollection[i].LineOne == newRoom.LineOne)
        //                    newRoom.AddNewRecord(SuggestionsCollection[i]);
        //            }
        //            bool flg1 = (i + 1 == SuggestionsCollection.Count()) && (roomChanged || SuggestionsCollection.Count()==1);
        //            bool flg2 = (i + 1 == SuggestionsCollection.Count()) && (houseChanged || SuggestionsCollection.Count()==1);
        //            if (SuggestionsCollection[i].LineOne != newRoom.LineOne || flg1)
        //            {
        //                roomChanged = true;
        //                _houses[housesCount].AddNewRoom(newRoom);
        //                newRoom = new Room(roomsCount, SuggestionsCollection[i].LineOne);
        //                roomsCount++;
        //                newRoom.AddNewRecord(SuggestionsCollection[i]);
        //            }
        //            if (SuggestionsCollection.Count() - i == 1 && SuggestionsCollection[i].LineOne != SuggestionsCollection[i - 1].LineOne)
        //            {
        //                roomChanged = true;
        //                _houses[housesCount].AddNewRoom(newRoom);
        //                newRoom = new Room(roomsCount, SuggestionsCollection[i].LineOne);
        //                roomsCount++;
        //                newRoom.AddNewRecord(SuggestionsCollection[i]);
        //            }
        //            if (SuggestionsCollection[i].ID != _houses[housesCount].LineOne || flg2)
        //            {
        //                houseChanged = true;
        //                roomsCount = 0;
        //                housesCount++;
        //                _houses.Add(new House(housesCount, SuggestionsCollection[i].ID));
        //            }
        //        }
        //    }
        //}

        public void AddCollectionToStructure()
        {
            if (SuggestionsCollection.Count() != 0)
            {
                string currentHouseID = SuggestionsCollection[0].ID, currentRoomID = SuggestionsCollection[0].LineOne;
                int houseCount = 0, roomCount = 0;
                _houses.Add(new House(houseCount, currentHouseID));
                _houses[0].AddNewRoom(new Room(roomCount, currentRoomID));
                for (int i = 0; i < SuggestionsCollection.Count(); i++)
                {
                    //Add new house if count went up
                    if(_houses.Count() - 1 != houseCount)
                    {
                        roomCount = 0;
                        currentHouseID = SuggestionsCollection[i].ID;
                        _houses.Add(new House(houseCount, currentHouseID));
                    }
                    
                    //Add new room if count went up
                    if(_houses[houseCount].HouseRooms.Count() - 1 != roomCount)
                    {
                        currentRoomID = SuggestionsCollection[i].LineOne;
                        _houses[houseCount].AddNewRoom(new Room(roomCount, currentRoomID));
                    }

                    if(currentHouseID != SuggestionsCollection[i].ID)
                    {
                        houseCount++;
                        i--;
                    }
                    else if(currentRoomID != SuggestionsCollection[i].LineOne)
                    {
                        roomCount++;
                        i--;
                    }
                    else
                    {
                        _houses[houseCount].HouseRooms[roomCount].AddNewRecord(SuggestionsCollection[i]);
                    }
                }
            }
        }
        
        
        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<SuggestionsViewModel> SuggestionsCollection { get; private set; }

        private string _sampleProperty = "Hello World";
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

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the SuggestionsCollection collection.
        /// </summary>
        public void LoadData(WizardViewModel DB)
        {
            using (IsolatedStorageFile isoStory = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("WizardResults.xml", FileMode.Open, isoStory))
                {
                    doc = XDocument.Load(isoStream, LoadOptions.PreserveWhitespace);
                    isoStream.Position = 0;
                    var data = from record in doc.Descendants("record")
                               select new SuggestionsViewModel
                               {	//other tags within the xml
                                   ID = record.Parent.Parent.Attribute("HouseID").Value.ToString(),
                                   LineOne = record.Parent.Attribute("RoomID").Value.ToString(),
                                   LineTwo = record.Attribute("RecordID").Value.ToString(),
                               };
                    List<SuggestionsViewModel> lst = data.ToList();
                    for (int i = 0; i < (lst.Count()); i++)
                    {
                        string suggestionID = lst[i].LineTwo;
                        lst[i].LineTwo = DB.QuestionsCollection[Array.IndexOf(DB.ItemIDs, suggestionID)].LineOne;
                        lst[i].LineThree = DB.QuestionsCollection[Array.IndexOf(DB.ItemIDs, suggestionID)].LineTwo;
                        lst[i].LineFour = DB.QuestionsCollection[Array.IndexOf(DB.ItemIDs, suggestionID)].LineThree;
                        this.SuggestionsCollection.Add(lst[i]);
                    }
                }
            }
            AddCollectionToStructure();
            this.IsDataLoaded = true;
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