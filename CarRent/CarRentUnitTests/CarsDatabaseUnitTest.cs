using CarRent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CarRentUnitTests
{
    [TestClass]
    public class CarsDatabaseUnitTest
    {
        string dataBasePath=@"C:\Users\user\Documents\Visual Studio 2015\Projects\CarRent\DataBase.json";
        [TestMethod]
        public void Car_IsCarAddedinGarage()
        {
            //arr
            var expected =new List<Car> { new Car("xxx", "yyy") };
            ClearDB();
            //act
            CarsDatabase.AddNewcarinDataBase(expected[0]);
            var actual = File.ReadAllText(dataBasePath)==JsonConvert.SerializeObject(expected);
            //ass
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void String_ItShouldbeListcar()
        {
            //arr
            var cars = new List<Car>() { new Car("audi", "blue"), new Car("bmw", "red"), new Car("lada", "grey") };
            var expected = JsonConvert.SerializeObject(cars);
            ClearDB();
            File.WriteAllText(dataBasePath, expected);
            //act
            var actual = JsonConvert.SerializeObject(CarsDatabase.DeserializeDatabase());
            //ass
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CarIdtoChangeStatus_WasStatuschanged()
        {
            //arr
            var cars = new List<Car>() { new Car("audi", "blue"), new Car("bmw", "red"), new Car("lada", "grey") };
            ClearDB();
            File.WriteAllText(dataBasePath, JsonConvert.SerializeObject(cars));
            //act
            CarsDatabase.ChangeCarStatusinDatabase(1, OccupationStatus.Rented);
            var actual = CarsDatabase.DeserializeDatabase()[1]._occupationStatus ==
                OccupationStatus.Rented;
            //ass
            Assert.IsTrue(actual);
        }       
        [TestMethod]
        public void CarIdandDateofReservation_WasAddedreservationinDB()
        {
            var cars = new List<Car>() { new Car("audi", "blue")};
            ClearDB();
            File.WriteAllText(dataBasePath, JsonConvert.SerializeObject(cars));
            //act
            CarsDatabase.ChangeCarStatusinDatabase(1, OccupationStatus.Rented);
            var actual = CarsDatabase.DeserializeDatabase()[1]._occupationStatus ==
                OccupationStatus.Rented;
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
