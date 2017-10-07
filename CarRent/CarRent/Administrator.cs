using System;
using Newtonsoft.Json;


namespace CarRent
{
    public static class Administrator
    {
        public static bool TakeCar(string reservationid)
        {
            try
            {
                var carlist = CarsDatabase.DeserializeDatabase();
                int id=0, carid=0;
                for(int i=0;i<carlist.Count;i++)
                {
                    if (carlist[i]._reservations.Count != 0)
                    {
                        id = carlist[i]._reservations.FindIndex(
                          j => j._reservationID == reservationid);
                        if (carlist[i]._reservations[id]._reservationID == reservationid)
                            carid = i;
                    }
                }
                carlist[carid].SendToRent();
                CarsDatabase.ChangeCarStatusinDatabase(carid, OccupationStatus.Rented);
                return true;
            }
            catch { return false; }
        }
        public static bool ReturnCar(string reservationid)
        {
            try
            {
                var carlist = CarsDatabase.DeserializeDatabase();
                int id = 0, carid = 0;
                for (int i = 0; i < carlist.Count; i++)
                {
                    if (carlist[i]._reservations.Count != 0)
                    {
                        id = carlist[i]._reservations.FindIndex(
                          j => j._reservationID == reservationid);
                        if (carlist[i]._reservations[id]._reservationID == reservationid)
                            carid = i;
                    }
                }
                //после 10 аренд машина автоматически отправляется на ТО
                if (carlist[carid].NeedItOnCheckup())
                {
                    SentCaronCheckup(carid);
                }
                CarsDatabase.ChangeCarStatusinDatabase(carid, OccupationStatus.Free);
                return true;
            }
            catch { return false; }
        }
        public static void AddNewCar(string model, string color)
        {
            var newcar = new Car(model, color);
            CarsDatabase.AddNewcarinDataBase(newcar);
        }
        public static void ReturnCarafterCheckup()
        {
            var carslist = CarsDatabase.DeserializeDatabase();
            for (int i = 0; i < carslist.Count - 1; i++)
            {
                if (DateTime.Today == carslist[i].GetdateofCheckupStart().AddDays(7))
                    CarsDatabase.ChangeCarStatusinDatabase(i, OccupationStatus.Free);
            }

        }
        public static void SentCaronCheckup(int carid)
        {
            CarsDatabase.ChangeCarStatusinDatabase(carid, OccupationStatus.OnCheckUp);
        }
    }
}
