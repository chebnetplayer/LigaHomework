using System;
using System.Collections.Generic;

namespace CarRent
{
    public class Car
    {
       public Car(string model, string color)
        {
            Model = model;
            Color = color;
            _reservations = new List<Reservation>();
            _occupationStatus = OccupationStatus.Unknown;
        }
        public void SendToRent()
        {
            _occupationStatus = OccupationStatus.Rented;
        }
        //метод, проверяющий нужно ли машину отвозить на ТО
        public bool NeedItOnCheckup()
        {
            bool needItOnCheckup=_reservations.Count%10==0;
            return needItOnCheckup;
        }
        public void SendToCheckUp()
        {
            _dateofCheckupStart = _reservations[_reservations.Count - 1]._endrent;
            _occupationStatus = OccupationStatus.OnCheckUp;
        }
        public bool IsFreeTorent(DateTime startrent, DateTime endrent)
        {
            bool checkonfree;
            checkonfree = _reservations.Count == 0;
            if (checkonfree == true)
                return true;
            checkonfree =(endrent<_reservations[0]._startrent)&&(startrent>=DateTime.Today);
            if (checkonfree == true)
                return true;
            for(int i=1;i<_reservations.Count-1;i++)
            {
                if ((startrent > _reservations[i]._endrent) && (endrent < _reservations[i + 1]._startrent))
                    return true;                    
            }
            checkonfree = startrent > _reservations[_reservations.Count-1]._endrent;
            if (checkonfree == true)
                return true;
            if(_dateofCheckupStart!=default(DateTime))
                checkonfree = startrent > _dateofCheckupStart.AddDays(7);
            if (checkonfree == true)
                return true;
            return false;
        }
        public void AddnewReservation(DateTime startrent,DateTime endrent)
        {
            _reservations.Add(new Reservation(startrent,endrent));
        }
        public DateTime GetdateofCheckupStart()
        {
            return _dateofCheckupStart;
        }
        public string Model { get; }
        public string Color { get; }
        //Поле для работы с БД;
        public OccupationStatus _occupationStatus;
        //поле публично, т.к. клиент с ним работать не будет;
        public List<Reservation> _reservations;
        private DateTime _dateofCheckupStart;
    }
}
