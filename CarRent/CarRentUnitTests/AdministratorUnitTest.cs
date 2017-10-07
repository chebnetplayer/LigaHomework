using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRent;
using System.IO;
using Newtonsoft.Json;

namespace CarRentUnitTests
{
    [TestClass]
    public class AdministratorUnitTest
    {
        string dataBasePath = @"C:\Users\user\Documents\Visual Studio 2015\Projects\CarRent\DataBase.json";
        [TestMethod]
        public void ReservationIdonCar_WasCarRented()
        {   //arr
            var carlist = new List<Car> { new Car("x1", "y1"), new Car("x2", "y2") };
            var client = new Client();
            ClearDB();
            File.AppendAllText(dataBasePath, JsonConvert.SerializeObject(carlist));
            var id = client.MakeReservation("x2", "y2", DateTime.Today, new DateTime(2017, 12, 24));
            //act
            var actual = Administrator.TakeCar(id);
            //ass
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ReservationIdonCar_WasCarReturned()
        {
            var carlist = new List<Car> { new Car("x1", "y1"), new Car("x2", "y2") };
            var client = new Client();
            ClearDB();
            File.AppendAllText(dataBasePath, JsonConvert.SerializeObject(carlist));
            var id = client.MakeReservation("x2", "y2", new DateTime(2017, 12, 19), DateTime.Today);
            //act
            var actual = Administrator.ReturnCar(id);
            //ass
            Assert.IsTrue(actual);
        }

        private void ClearDB()
        {
            File.WriteAllText(dataBasePath, "");
            CarsDatabase.ChangeDBpath(dataBasePath);
        }
    }
}
