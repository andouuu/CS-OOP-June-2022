using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        [Test]
        public void NameShouldThrowExceptionWhenNullOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>
            (() =>
            {
                //Arrange & Act
                var aquarium = new Aquarium(null, 10);
            }//Assert
                , "Invalid aquarium name!");
            Assert.Throws<ArgumentNullException>
            (() =>
            {
                //Arrange & Act
                var aquarium = new Aquarium(string.Empty, 10);
            }   //Assert
                , "Invalid aquarium name!");
        }

        [Test]
        public void NameShouldWorkProperlyWhenInputIsCorrect()
        {
            //Arrange
            string expectedName = "aquarium";
            //Act
            var aquarium=new Aquarium(expectedName, 10);
            //Assert
            Assert.That(aquarium.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenValueIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium("a", -5);
            }, "Invalid aquarium capacity!");

        }
        [Test]
        public void CapacityShouldWorkProperlyWhenInputIsCorrect()
        {
            //Arrange
            int expectedCapacity = 10;
            //Act
            var aquarium = new Aquarium("expectedName", expectedCapacity);
            //Assert
            Assert.AreEqual(expectedCapacity, aquarium.Capacity);
        }

        [Test]
        public void AddShouldThrowExceptionWhenAquariumIsFull()
        {
            //Arrange
            var aquarium = new Aquarium("bob", 1);
            //Act
            aquarium.Add(new Fish("johny"));
            //Assert
            Assert.Throws<InvalidOperationException>
                (() => aquarium.Add(new Fish("stevie")));
        }

        [Test]
        public void AddShouldAddFishWhenAquariumIsNotFull()
        {
            //Arrange
            var aquarium = new Aquarium("bob", 2);
            //Act
            aquarium.Add(new Fish("johny"));
            aquarium.Add(new Fish("pete"));
            //Assert
            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void RemoveFishShouldThrowExceptionWhenFishDoesNotExist()
        {
            //Arrange
            var aquarium = new Aquarium("bob", 2);
            //Act
            aquarium.Add(new Fish("johny"));
            aquarium.Add(new Fish("pete"));
            //Assert
            Assert.Throws<InvalidOperationException>
                ((() => aquarium.RemoveFish("bobby")));
        }

        [Test]
        public void RemoveFishShouldWorkWhenFishExists()
        {
            //Arrange
            var aquarium = new Aquarium("bob", 2);
            //Act
            aquarium.Add(new Fish("johny"));
            aquarium.Add(new Fish("pete"));
            aquarium.RemoveFish("johny");
            //Assert
            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void SellFishShouldThrowExceptionWhenFishDoesNotExist()
        {
            //Arrange
            var aquarium = new Aquarium("bob", 2);
            //Act
            aquarium.Add(new Fish("johny"));
            aquarium.Add(new Fish("pete"));
            //Assert
            Assert.Throws<InvalidOperationException>
                ((() => aquarium.SellFish("bobby")));
        }
        [Test]
        public void SellFishShouldWorkWhenFishExists()
        {
            //Arrange
            var aquarium = new Aquarium("bob", 2);
            //Act
            Fish fishToSell = new Fish("johny");
            aquarium.Add(fishToSell);
            aquarium.Add(new Fish("pete"));
            
            //Assert
            Assert.AreEqual(fishToSell, aquarium.SellFish("johny"));
        }
        [Test]
        public void ReportTest()
        {
            var fish = new Fish("Gosho");
            var fish1 = new Fish("Pesho");
            var aqua = new Aquarium("stoqn", 3);
            aqua.Add(fish);
            aqua.Add(fish1);
            Assert.AreEqual("Fish available at stoqn: Gosho, Pesho", aqua.Report());
        }
    }
}
