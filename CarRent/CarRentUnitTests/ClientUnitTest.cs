using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRent;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace CarRentUnitTests
{
    [TestClass]
    public class ClientUnitTest
    {
        string dataBasePath = @"C:\Users\user\Documents\Visual Studio 2015\Projects\CarRent\DataBase.json";
        [TestMethod]
        public void Cars_FreeCars()
        {
            //arr
            var carlist = new List<Car> { new Car("x1", "y1"), new Car("x2", "y2")};
            ClearDB();
            carlist[0]._reservations.Add(new Reservation(new DateTime(2017, 12, 12), new DateTime(2017, 12, 20)));
            File.AppendAllText(dataBasePath, JsonConvert.SerializeObject(carlist));
            var client = new Client();
            //act
            var actual="x2; y2"+Environment.NewLine==client.GetFreeCar(new DateTime(2017, 12, 19), new DateTime(2017, 12, 24));
            //ass
            Assert.IsTrue(actual);

        }
        [TestMethod]
        public void ReservationonCar_IscaronReservations()
        {
            //arr
            var carlist = new List<Car> { new Car("x1", "y1"), new Car("x2", "y2") };
            var expected = "10";
            ClearDB();
            carlist[0]._reservations.Add(new Reservation(new DateTime(2017, 12, 12), new DateTime(2017, 12, 20)));
            File.AppendAllText(dataBasePath, JsonConvert.SerializeObject(carlist));
            var client = new Client();
            //act
            var actual = client.MakeReservation("x2", "y2", new DateTime(2017, 12, 19), new DateTime(2017, 12, 24));
            //ass
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReservationonCaronBusyDate_IscaronReservations()
        {
            //arr
            var carlist = new List<Car> { new Car("x1", "y1"), new Car("x2", "y2") };
            var expected = "FAIL";
            ClearDB();
            carlist[0]._reservations.Add(new Reservation(new DateTime(2017, 12, 12), new DateTime(2017, 12, 20)));
            File.AppendAllText(dataBasePath, JsonConvert.SerializeObject(carlist));
            var client = new Client();
            //act
            var actual = client.MakeReservation("x1", "y1", new DateTime(2017, 12, 19), new DateTime(2017, 12, 24));
            //ass
            Assert.AreEqual(expected, actual);
        }
        private void ClearDB()
        {
            File.WriteAllText(dataBasePath, "");
            CarsDatabase.ChangeDBpath(dataBasePath);
        }
    }
}
