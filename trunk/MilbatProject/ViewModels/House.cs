using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilbatProject.ViewModels
{
    public class House
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        
        private string _houseID;

        public string LineOne
        {
            get { return _houseID; }
            set { _houseID = value; }
        }

        private string _lineTwo;

        public string LineTwo
        {
            get { return _lineTwo; }
            set { _lineTwo = value; }
        }
        

        private List<Room> _houseRooms;

        public List<Room> HouseRooms
        {
            get { return _houseRooms; }
            set { _houseRooms = value; }
        }
        
        public House(int id, string houseID)
        {
            this._id = id;
            this._houseID = houseID;
            this._houseRooms = new List<Room>();
        }

        public void AddNewRoom(Room newRoom)
        {
            _houseRooms.Add(newRoom);
        }
    }
}
