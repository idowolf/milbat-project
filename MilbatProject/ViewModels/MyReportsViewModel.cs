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
        private List<string> questionTitles = new List<string>();

        public List<string> QuestionTitles
        {
            get { return questionTitles; }
            set { questionTitles = value; }
        }
        
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

        public int CalculateSafetyScale(string currentHouse)
        {
            int maxCount = 0, housePointer = WheresMyHouse(currentHouse), suggestionCount = 0;
            double safetyScale = 0;

            for (int i = 0; i < _houses[housePointer].HouseRooms.Count(); i++)
            {

                for (int k = 0; k < _houses[housePointer].HouseRooms[i].RoomRecords.Count(); k++)
                {
                    suggestionCount++;
                }
            }
            for (int i = 0; i < _houses[housePointer].HouseRooms.Count(); i++)
            {
                                //maxCount += _houses[housePointer].HouseRooms[i].RoomRecords.Count();
                maxCount += GetRoomMaxCount(questionTitles[i]);

            }

            safetyScale = (maxCount - suggestionCount) / (double)maxCount * 100;
            if (safetyScale < 25)
                safetyScale = 0;
            else if (safetyScale >= 25 && safetyScale < 50)
                safetyScale = 25;
            else if (safetyScale >= 50 && safetyScale < 75)
                safetyScale = 50;
            else if (safetyScale >= 75 && safetyScale < 85)
                safetyScale = 75;
            else
                safetyScale = 100;

            return (int)safetyScale;
        }

        public int GetRoomMaxCount(string title)
        {
            return int.Parse(title.Substring(title.IndexOf("מתוך ") + 4));
        }

        public int WheresMyHouse(string houseName)
        {
            for (int i = 0; i < _houses.Count(); i++)
            {
                if (_houses[i].LineOne == houseName)
                    return i;
            }
            return 0;
        }

        public void AddCollectionToStructure()
        {
            if (SuggestionsCollection.Count() != 0)
            {
                string currentHouseID = SuggestionsCollection[0].ID, currentRoomID = SuggestionsCollection[0].LineOne;
                int houseCount = 0, roomCount = 0;
                _houses.Add(new House(houseCount, currentHouseID));
                _houses[0].AddNewRoom(new Room(roomCount, currentRoomID,GetRoomMaxCount(questionTitles[0])));
                for (int i = 0; i < SuggestionsCollection.Count(); i++)
                {
                    if (i > 0)
                    {
                        if (_houses.Count() - 1 != houseCount)
                        {
                            roomCount = 0;
                            currentHouseID = SuggestionsCollection[i].ID;
                            _houses.Add(new House(houseCount, currentHouseID));
                        }
                    }
                    //Add new room if count went up
                    if ( i > 0)
                    { 
                        if(_houses[houseCount].HouseRooms.Count() - 1 != roomCount)
                    {
                        currentRoomID = SuggestionsCollection[i].LineOne;
                        _houses[houseCount].AddNewRoom(new Room(roomCount, currentRoomID, GetRoomMaxCount(questionTitles[roomCount])));
                    }
                    }

                    //Add new house if count went up

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
                int ab = roomCount;
                    //_houses[houseCount].AddNewRoom(new Room(roomCount, currentRoomID, GetRoomMaxCount(questionTitles[roomCount])));
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
            WizardResultsViewModel.StaticCreateNewFileIfNecessary();
            using (IsolatedStorageFile isoStory = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if(isoStory.FileExists("WizardResults.xml"))
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
                        questionTitles.Add(DB.QuestionsCollection[(Array.IndexOf(DB.ItemIDs,suggestionID))].QuestionTitle);
                        lst[i].LineTwo = DB.QuestionsCollection[Array.IndexOf(DB.ItemIDs, suggestionID)].LineOne;
                        lst[i].LineThree = DB.QuestionsCollection[Array.IndexOf(DB.ItemIDs, suggestionID)].LineTwo;
                        lst[i].LineFour = DB.QuestionsCollection[Array.IndexOf(DB.ItemIDs, suggestionID)].LineThree;
                        this.SuggestionsCollection.Add(lst[i]);
                    }
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