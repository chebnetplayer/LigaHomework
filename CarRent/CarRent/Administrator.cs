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
                var car = carlist.Find(
                    i => i._reservations.Find(j => j._reservationID == reservationid)._reservationID == reservationid);
                var carid = carlist.FindIndex(
                    i => i._reservations.Find(j => j._reservationID == reservationid)._reservationID == reservationid);
                car.SendToRent();
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
                var car = carlist.Find(
                    i => i._reservations.Find(j => j._reservationID == reservationid)._reservationID == reservationid);
                var carid = carlist.FindIndex(
                    i => i._reservations.Find(j => j._reservationID == reservationid)._reservationID == reservationid);
                //после 10 аренд машина автоматически отправляется на ТО
                if (car.NeedItOnCheckup())
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
        public static void ReturnCarAfterCheckUp()
        {

        }
        public static void ReturnCaronCheckup()
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
           var carslist = CarsDatabase.DeserializeDatabase();
           foreach(var i in carslist)
            {
                if (DateTime.Today ==i.GetdateofCheckupStart().AddDays(7))
                    CarsDatabase.ChangeCarStatusinDatabase(carid, OccupationStatus.Free);
            }         
        }
    }
}
