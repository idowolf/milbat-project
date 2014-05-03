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
    public class WizardViewModel : INotifyPropertyChanged
    {
        private XDocument doc = XDocument.Load("MilbatDatabase.xml");
        public WizardViewModel()
        {
            this.QuestionsCollection = new ObservableCollection<QuestionViewModel>();
            this.AllQuestions = new ObservableCollection<QuestionViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<QuestionViewModel> QuestionsCollection { get; private set; }
        public ObservableCollection<QuestionViewModel> AllQuestions { get; private set; }
        public string[] ItemIDs { get; private set; }
        private int[] _questionsPerArea = new int[13];

        public int[] QuestionsPerArea
        {
            get { return _questionsPerArea; }
            set
            {
                if (value != _questionsPerArea)
                {
                    _questionsPerArea = value;
                    NotifyPropertyChanged("QuestionsCollectionCount");
                }
            }
        }
        public void GetQuestionsPerArea()
        {
            var data = from item in doc.Descendants("area")
                       select item.Attribute("QuestionCount").Value.ToString();
            List<string> lst = data.ToList();
            for (int i = 0; i < _questionsPerArea.Length; i++)
            {
                _questionsPerArea[i] = int.Parse(lst[i]);
            }
        }

        private int sectionPointer { get; set; }
        private int areaPointer { get; set; }
        private int questionPointer { get; set; }
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
        /// Creates and adds a few ItemViewModel objects into the QuestionsCollection collection.
        /// </summary>
        public void LoadData(string RoomName)
        {
            // Sample data; replace with real data
            var data = from item in doc.Descendants("record")
                       where (string)item.Parent.Attribute("Name")==RoomName
                       select new QuestionViewModel
                       {	//other tags within the xml
                           ID = item.Element("ID").Value.ToString(),
                           LineOne = item.Element("subject").Value.ToString(),
                           LineTwo = item.Element("question").Value.ToString(),
                           LineThree = item.Element("suggestion").Value.ToString(),
                       };
            GetQuestionsPerArea();
            List<QuestionViewModel> lst = data.ToList();
            ItemIDs = new string[lst.Count()];
            for (int i = 0; i < (lst.Count()); i++)
            {
                lst[i].QuestionTitle = SetQuestionTitle(lst[i]);
                this.QuestionsCollection.Add(lst[i]);
                this.ItemIDs[i] = lst[i].ID;
            }
            this.IsDataLoaded = true;
        }

        public void LoadData()
        {
            // Sample data; replace with real data
            var data = from item in doc.Descendants("record")
                       select new QuestionViewModel
                       {	//other tags within the xml
                           ID = item.Element("ID").Value.ToString(),
                           LineOne = item.Element("subject").Value.ToString(),
                           LineTwo = item.Element("question").Value.ToString(),
                           LineThree = item.Element("suggestion").Value.ToString(),
                       };
            GetQuestionsPerArea();
            List<QuestionViewModel> lst = data.ToList();
            ItemIDs = new string[lst.Count()];
            for (int i = 0; i < (lst.Count()); i++)
            {
                lst[i].QuestionTitle = SetQuestionTitle(lst[i]);
                this.QuestionsCollection.Add(lst[i]);
                this.ItemIDs[i] = lst[i].ID;
            }
            this.IsDataLoaded = true;
        }

        public string SetQuestionTitle(QuestionViewModel item)
        {
            string questionTitle = "שאלה ";

            int pFrom = item.ID.LastIndexOf('.') + 1;
            int pTo = item.ID.Length;
            questionTitle += int.Parse(item.ID.Substring(pFrom, pTo - pFrom));

            questionTitle += " מתוך ";

            questionTitle += _questionsPerArea[GetCurrentArea(item)];
            return questionTitle;
        }

        public int GetCurrentArea(QuestionViewModel item)
        {
            int pFrom = item.ID.IndexOf('.') + 1;
            int pTo = item.ID.LastIndexOf(".");

            int a = int.Parse(item.ID.Substring(pFrom, pTo - pFrom)) - 1;

            return int.Parse(item.ID.Substring(pFrom, pTo - pFrom)) - 1;
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