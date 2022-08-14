using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void PriceShouldThrowExceptionWhenNegative()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var weapon = new Weapon("name", -1, 5);
                });
            }

            [Test]
            public void PriceShouldBeCorrectWhenNotNegative()
            {
                var expectedPrice = 5;
                var weapon=new Weapon("name", expectedPrice, 5);
                Assert.That(weapon.Price,Is.EqualTo(expectedPrice));
            }
            [Test]
            public void IncreaseDestructionMethodShouldWorkProperly()
            {
                var weapon = new Weapon("name", 15, 4);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.DestructionLevel, Is.EqualTo(5));
            }

            [Test]
            public void IsNuclearShouldWorkProperlyWhenDestructionLevelIsBiggerThanTen()
            {
                var weapon = new Weapon("name", 15, 10);
                Assert.That(weapon.IsNuclear == true);
            }
            [Test]
            public void PlanetNameShouldThrowExceptionWhenNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(null, 5);
                });
            }
            [Test]
            public void PlanetNameShouldBeCorrectWhenNotNullOrEmpty()
            {
                var expectedName = "name";
                var planet= new Planet(expectedName, 5);
                Assert.That(planet.Name, Is.EqualTo(expectedName));
            }
            [Test]
            public void BudgetShouldThrowExceptionWhenNegative()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet("name", -1);
                });
            }

            [Test]
            public void MilitaryPowerRatioShouldWorkProperly()
            {
                const int expectedPowerRatio = 10; 
                var planet = new Planet("name", 500);
                planet.AddWeapon(new Weapon("rifle",5,5));
                planet.AddWeapon(new Weapon("pistol",5,5));
                Assert.That(planet.MilitaryPowerRatio,Is.EqualTo(expectedPowerRatio));
            }
            
            [Test]
            public void ProfitMethodShouldWork()
            {
                var planet = new Planet("name", 1);
                planet.Profit(9);
                Assert.That(planet.Budget, Is.EqualTo(10));
            }
            [Test]
            public void SpendFundsMethodShouldThrowExceptionWhenAmountIsNotEnough()
            {


                Assert.Throws<InvalidOperationException>(() =>
                {
                    var planet = new Planet("name", 1);
                    planet.SpendFunds(5);
                });
            }
            [Test]
            public void SpendFundsMethodShouldWorkWhenAmountIsEnough()
            {
                var planet = new Planet("name", 10);
                planet.SpendFunds(9);
                Assert.That(planet.Budget, Is.EqualTo(1));
            }
            [Test]
            public void AddWeaponShouldThrowExceptionWhenThereIsWeaponWithTheSameName()
            {

                var planet = new Planet("name", 2);
                planet.AddWeapon(new Weapon("weapon", 5, 5));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    
                    planet.AddWeapon(new Weapon("weapon", 5, 5));
                });
            }
            [Test]
            public void AddWeaponShouldWorkWhenWeaponWithSameNameDoesNotExist()
            {
                var expectedCount = 1;
                var weapon1 = new Weapon("weapon", 5, 5);
                var planet = new Planet("name", 2);
                planet.AddWeapon(weapon1);
                var receivedCount = planet.Weapons.Count;
                Assert.That(receivedCount, Is.EqualTo(expectedCount));
            }
            [Test]
            public void RemoveWeaponShouldWorkProperly()
            {
                var expectedCount=0;
                var weapon1 = new Weapon("weapon", 5, 5);
                var planet = new Planet("name", 2);
                planet.AddWeapon(weapon1);
                planet.RemoveWeapon(weapon1.Name);
                var receivedCount = planet.Weapons.Count;
                Assert.That(receivedCount, Is.EqualTo(expectedCount));
            }
            [Test]
            public void UpgradeWeaponShouldThrowExceptionWhenWeaponDoesNotExist()
            {
                var planet = new Planet("name", 500);
                planet.AddWeapon(new Weapon("rifle", 5, 5));
                planet.AddWeapon(new Weapon("pistol", 5, 5));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("AK-47");
                });
            }
            [Test]
            public void UpgradeWeaponShouldWorkProperlyWhenWeaponDoesExist()
            {
                var expectedDestructionLevel = 6;
                var planet = new Planet("name", 500);
                planet.AddWeapon(new Weapon("rifle", 5, 5));
                planet.AddWeapon(new Weapon("pistol", 5, 5));
                planet.UpgradeWeapon("rifle");
                var rifle = planet.Weapons.First(x => x.Name == "rifle");
                Assert.That(rifle.DestructionLevel,Is.EqualTo(expectedDestructionLevel));
            }

            [Test]
            public void DestructOpponentShouldThrowExceptionWhenPowerRatioIsNotBiggerThanOpponent()
            {
                var planet = new Planet("name", 500);
                planet.AddWeapon(new Weapon("rifle", 5, 5));
                planet.AddWeapon(new Weapon("pistol", 5, 5));
                var secondPlanet=new Planet("name2", 500);
                secondPlanet.AddWeapon(new Weapon("bazooka",5,11));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(secondPlanet);
                });
            }
            [Test]
            public void DestructOpponentShouldWorkWhenPowerRatioIsBiggerThanOpponents()
            {
                var expectedOutput = $"name2 is destructed!";
                var planet = new Planet("name", 500);
                planet.AddWeapon(new Weapon("rifle", 5, 7));
                planet.AddWeapon(new Weapon("pistol", 5, 5));
                var secondPlanet = new Planet("name2", 500);
                secondPlanet.AddWeapon(new Weapon("bazooka", 5, 11));
                string output=planet.DestructOpponent(secondPlanet);
                Assert.That(output,Is.EqualTo(expectedOutput));
            }
        }
    }
}
