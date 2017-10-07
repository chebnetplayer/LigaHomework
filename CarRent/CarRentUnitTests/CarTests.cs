using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRent;

namespace CarRentUnitTests
{
    [TestClass]
    public class CarTests
    {      
        [TestMethod]
        public void CarWithReservations_IsFreetoRentonDate()
        {   
            //arr
            var car = new Car("Ford Focus 3", "black");
            car._reservations.Add(new Reservation(new DateTime(2017,10,9), 
                new DateTime(2017,10,15)));
            //act
            var actual = car.IsFreeTorent(new DateTime(2017, 10, 9), new DateTime(2017, 10, 9));
            //assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void CarsWithReservations_NeedItonCheckUp()
        {
            //arr
            var car = new Car("Lada Vesta", "White");
            for (int i = 0; i < 9; i++)
                car._reservations.Add(new Reservation(new DateTime(2017, 11, 1), new DateTime(2017, 11, 5)));
            car._reservations.Add(new Reservation(new DateTime(2017, 11, 10), new DateTime(2017, 11, 20)));
            //act
            var actual = car.NeedItOnCheckup();
            //ass
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void CarsWithReservations_SendItonCheckUp()
        {
            //arr
            var car = new Car("Lada Vesta", "White");
            for (int i = 0; i < 9; i++)
                car._reservations.Add(new Reservation(new DateTime(2017, 11, 1), new DateTime(2017, 11, 5)));
            car._reservations.Add(new Reservation(new DateTime(2017, 11, 10), new DateTime(2017, 11, 20)));
            //act
            car.SendToCheckUp();
            var actual = car.GetdateofCheckupStart() ==
                car._reservations[car._reservations.Count - 1]._endrent;
            //ass
            Assert.IsTrue(actual);
        }
    }
}