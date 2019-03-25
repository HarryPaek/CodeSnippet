using System;

namespace IListSourceImplementation.Models
{
    public class Employee : BusinessObjectBase
    {
        private string _id;
        private string _name;
        private Decimal _parkingId;

        public Employee() : this(string.Empty, 0) { }
        public Employee(string name) : this(name, 0) { }

        public Employee(string name, Decimal parkingId) : base()
        {
            this._id = System.Guid.NewGuid().ToString();

            // Set values
            this._name = name;
            this._parkingId = parkingId;
        }

        public string ID
        {
            get { return _id; }
        }

        const string NAME = "Name";
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value) {
                    _name = value;

                    // Raise the PropertyChanged event.
                    OnPropertyChanged(NAME);
                }
            }
        }

        const string PARKING_ID = "Salary";
        public Decimal ParkingID
        {
            get { return _parkingId; }
            set
            {
                if (_parkingId != value) {
                    _parkingId = value;

                    // Raise the PropertyChanged event.
                    OnPropertyChanged(PARKING_ID);
                }
            }
        }
    }
}
