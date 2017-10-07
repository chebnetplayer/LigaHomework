using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarRent
{
    public static class CarsDatabase
    {
        //инкапсуляция адреса БД
        public static void ChangeDBpath(string path)
        {
            DatabasePath = path;
        }
        //добавление новой машины в гараж
        public static void AddNewcarinDataBase(Car car)
        {
            List<Car> carlist = DeserializeDatabase();
            if (carlist == null)
                carlist = new List<Car>();
            carlist.Add(car);
            File.WriteAllText(DatabasePath, JsonConvert.SerializeObject(carlist));         
        }
        //получение списка машин из БД
        public static List<Car> DeserializeDatabase()
        {
            return JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(DatabasePath));         
        }
        //замена статуса машины в БД, в метод приходит номер строки, которую нужно изменить
        public static bool ChangeCarStatusinDatabase(int carid,OccupationStatus occupationstatus)
        {            
            //если true-то статус поменялся, если false-возникла ошибка
            try
            {
                var carlist = DeserializeDatabase();
                carlist[carid]._occupationStatus = occupationstatus;
                File.WriteAllText(DatabasePath, JsonConvert.SerializeObject(carlist));
                return true;
            }
            catch
            {
                return false;
            }
            //если true-то статус поменялся, если false-возникла ошибка
        }
        //если машину забронировали- это будет в базе
        public static string AddReservationsonCar(int carid, DateTime startrent, DateTime endrent)
        {
            try
            {
                var carlist = DeserializeDatabase();
                carlist[carid].AddnewReservation(startrent,endrent);
                carlist[carid]._reservations[carlist[carid]._reservations.Count - 1]._reservationID =
                   carid.ToString() + (carlist[carid]._reservations.Count - 1).ToString();
                File.WriteAllText(DatabasePath, JsonConvert.SerializeObject(carlist));
                return carlist[carid]._reservations[carlist[carid]._reservations.Count - 1]._reservationID;
            }
            catch
            {
                return "-1";
            }
        }
        public static void ResetDataBase()
        {
            File.WriteAllText(DatabasePath, "");
        }
        public static void ResetAllReservations()
        {
            var carlist = DeserializeDatabase();
            foreach (var i in carlist)
                i._reservations = new List<Reservation>();
            File.WriteAllText(DatabasePath, JsonConvert.SerializeObject(carlist));
        }

        static string DatabasePath;
    }
}
