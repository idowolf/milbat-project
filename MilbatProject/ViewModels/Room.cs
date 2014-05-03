using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilbatProject.ViewModels
{
    public class Room
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private string _roomID;

        public string LineOne
        {
            get { return _roomID; }
            set { _roomID = value; }
        }

        private List<SuggestionsViewModel> _roomRecords;

        public List<SuggestionsViewModel> RoomRecords
        {
            get { return _roomRecords; }
            set { _roomRecords = value; }
        }

        public Room(int id, string roomID)
        {
            this._id = id;
            this._roomID = roomID;
            this._roomRecords = new List<SuggestionsViewModel>();
        }

        public void AddNewRecord(SuggestionsViewModel newRecord)
        {
            this._roomRecords.Add(newRecord);
        }
    }
}
