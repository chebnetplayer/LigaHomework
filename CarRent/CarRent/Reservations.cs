using System;
using Newtonsoft.Json;


namespace CarRent
{
    public class Reservation
    {           
        public Reservation(DateTime startrent, DateTime endrent)
        {
            _startrent = startrent;
            _endrent = endrent;
        }
       public  DateTime _startrent;
       public  DateTime _endrent;
       public string _reservationID;
    }
}
