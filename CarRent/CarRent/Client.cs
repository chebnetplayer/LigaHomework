using System;


namespace CarRent
{
    public class Client
    {
        public string GetFreeCar(DateTime startrent, DateTime endrent)
        {
            var listcars = CarsDatabase.DeserializeDatabase();
            string freecars = "";
            foreach(var i in listcars)
            {
                if (i.IsFreeTorent(startrent, endrent))
                    freecars += i.Model + "; " + i.Color + Environment.NewLine;
            }
            if (freecars != "") return freecars;
            else return "Свободных машин нет";
        }
        public string MakeReservation(string model,string color,DateTime startrent,DateTime endrent)
        {
            try
            {
                var cars = CarsDatabase.DeserializeDatabase();
                var freecar = cars.Find(i => i.Color == color && i.Model == model && i.IsFreeTorent(startrent, endrent));
                var freecarid = cars.FindIndex(i => i.Color == color && i.Model == model && i.IsFreeTorent(startrent, endrent));
                return  CarsDatabase.AddReservationsonCar(freecarid, startrent, endrent);            
            }
            catch { return "FAIL"; }
        }      
    }
}
