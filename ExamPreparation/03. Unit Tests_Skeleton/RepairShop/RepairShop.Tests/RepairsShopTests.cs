using System;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            //Car Tests
            [Test]
            public void CarModelShouldBeSameAsTheOneEnteredInTheConstructor()
            {
                //Arrange
                Car car = new Car("BMW", 0);
                //Act
                string expectedModel = "BMW";
                string actualModel = car.CarModel;
                //Assert
                Assert.AreEqual(expectedModel, actualModel);
            }
            [Test]
            public void NumberOfIssuesShouldBeSameAsTheOneEnteredInTheConstructor()
            {
                //Arrange
                Car car = new Car("BMW", 43);
                //Act
                int expectedIssues = 43;
                int actualIssues = car.NumberOfIssues;
                //Assert
                Assert.AreEqual(expectedIssues, actualIssues);
            }

            [Test]
            public void IsFixedShouldBeTrueWhenNumberOfIssuesIsZero()
            {
                //Arrange
                Car car = new Car("BMW", 0);
                //Assert
                Assert.IsTrue(car.IsFixed);
            }
            [Test]
            public void IsFixedShouldBeTrueWhenNumberOfIssuesIsMoreThanZero()
            {
                //Arrange
                Car car = new Car("BMW", 5);
                //Assert
                Assert.IsFalse(car.IsFixed);
            }

            //Garage Tests
            [Test]
            public void GarageNameShouldBeSameAsTheOneEnteredInTheConstructor()
            {
                //Arrange
                Garage garage = new Garage("garage", 1);
                //Act
                string expectedName = "garage";
                string actualName = garage.Name;
                //Assert
                Assert.AreEqual(expectedName, actualName);
            }
            [Test]
            public void NumberOfMechanicsShouldBeSameAsTheOneEnteredInTheConstructor()
            {
                //Arrange
                Garage garage = new Garage("garage", 6);
                //Act
                int expectedMechanics = 6;
                int actualMechanincs = garage.MechanicsAvailable;
                //Assert
                Assert.AreEqual(expectedMechanics, actualMechanincs);
            }
            [Test]
            public void ShouldThrowExceptionWhenNameIsNullOrEmpty()
            {
                //Assert
                Assert.Throws<ArgumentNullException>(() => new Garage(null, 5));
            }

            [Test]
            public void ShouldWorkProperlyWhenNameIsNotNullOrEmpty()
            {
                //Arrange
                Garage garage = new Garage("garaj", 5);
                //Act
                string expectedName = "garaj";
                //Assert
                Assert.AreEqual(expectedName, garage.Name);
            }

            [Test]
            public void ShouldThrowExceptionWhenMechanicsAreLessOrEqualThanZero()
            {
                //Assert
                Assert.Throws<ArgumentException>(() => new Garage("garage", -5));
            }

            [Test]
            public void ShouldWorkProperlyWhenMechanicsAreMoreThanZero()
            {
                //Arrange
                Garage garage = new Garage("garage", 5);
                //Act
                int expectedMechanics = 5;
                //Assert
                Assert.AreEqual(expectedMechanics, garage.MechanicsAvailable);
            }

            [Test]
            public void CarsInGarageShouldBeEqualToCarsCount()
            {
                //Arrange
                Garage garage = new Garage("garage", 5);
                //Act
                garage.AddCar(new Car("BMW",0));
                //Assert
                Assert.AreEqual(1,garage.CarsInGarage);
            }

            [Test]
            public void AddingCarShouldThrowExceptionWhenCountIsEqualToMechanicsAvailable()
            {
                //Arrange
                Garage garage = new Garage("garage", 1);
                //Act
                garage.AddCar(new Car("BMW",1));
                //Assert
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(new Car("Audi", 50)));
            }
            [Test]
            public void AddingCarShouldWorkProperlyWhenCountIsLessThanMechanicsAvailable()
            {
                //Arrange
                Garage garage = new Garage("garage", 2);
                //Act
                garage.AddCar(new Car("BMW", 1));
                garage.AddCar(new Car("Audi", 50));
                //Assert
                Assert.AreEqual(2,garage.CarsInGarage);
            }

            [Test]
            public void FixCarShouldThrowExceptionWhenSearchedCarDoesNotExist()
            {
                //Arrange
                Garage garage = new Garage("garage", 2);
                //Act
                garage.AddCar(new Car("BMW", 1));
                garage.AddCar(new Car("Audi", 50));
                //Assert
                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Fiat"));
            }
            [Test]
            public void FixCarShouldWorkProperlyWhenSearchedCarExist()
            {
                //Arrange
                Garage garage = new Garage("garage", 2);
                //Act
                garage.AddCar(new Car("BMW", 1));
                garage.AddCar(new Car("Audi", 50));
                garage.FixCar("BMW");
                garage.RemoveFixedCar();
                //Assert
                Assert.AreEqual(1,garage.CarsInGarage);
            }

            [Test]
            public void RemoveFixedCarShouldThrowExceptionWhenThereAreNoFixedCarsAvailable()
            {
                //Arrange
                Garage garage = new Garage("garage", 2);
                //Act
                garage.AddCar(new Car("BMW", 1));
                garage.AddCar(new Car("Audi", 50));
                //Assert
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }
            [Test]
            public void RemoveFixedCarShouldWorkProperlyWhenThereAreFixedCars()
            {
                //Arrange
                Garage garage = new Garage("garage", 2);
                //Act
                garage.AddCar(new Car("BMW", 1));
                garage.AddCar(new Car("Audi", 0));
                garage.FixCar("BMW");
                garage.RemoveFixedCar();
                //Assert
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void ReportShouldPrintCorrectMessage()
            {
                //Arrange
                Garage garage = new Garage("garage", 3);
                garage.AddCar(new Car("BMW", 1));
                garage.AddCar(new Car("Audi", 50));
                garage.AddCar(new Car("VW",0));
                //Act
                string expectedMessage = $"There are 2 which are not fixed: BMW, Audi.";
                //Assert'
                Assert.AreEqual(expectedMessage,garage.Report());
            }
        }
    }
}