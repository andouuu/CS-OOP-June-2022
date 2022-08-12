using System;
using System.ComponentModel;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void AddingUsersWithSameUsernameShouldThrowException()
        {
            //Arrange
            var database = new Database();
            var firstPerson = new Person(1, "username");
            var secondPerson = new Person(2, "username");

            //Act
            database.Add(firstPerson);
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(secondPerson));
        }

        [Test]
        public void AddingUsersWithSameIDShouldThrowException()
        {
            //Arrange
            var database = new Database();
            var firstPerson = new Person(1, "username");
            var secondPerson = new Person(1, "username2");
            //Act
            database.Add(firstPerson);
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(secondPerson));
        }

        [Test]
        public void AddingUsersWhenDatabaseIsFullShouldThrowException()
        {
            //Arrange
            var database = new Database();
            //Act
            for (int i = 1; i <= 16; i++)
            {
                database.Add(new Person(i, $"username{i}"));
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "username17")));
        }

        [Test]
        public void RemoveShouldDecreaseCountWhenSuccessful()
        {
            //Arrange
            var database = new Database(new Person(1, "username"));
            //Act
            database.Remove();

            var expectedCount = 0;
            var actualCount = database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseEmpty()
        {
            //Arrange
            var database = new Database(new Person(1, "username"));
            //Act
            database.Remove();


            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenUsernameIsNotFound()
        {
            //Arrange
            var database = new Database();
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("username"));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenParameterIsNull()
        {
            //Arrange
            var database = new Database();

            //Assert
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void FindByIDShouldThrowExceptionWhenUsernameIsNotFound()
        {
            //Arrange
            var database = new Database();
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindById(1));
        }

        [Test]
        public void FindByIDShouldThrowExceptionWhenParameterIsNegative()
        {
            //Arrange
            var database = new Database();

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-5));
        }

        [Test]
        public void SearchingForValidUsernameInTheDatabaseShouldReturnCorrectResult()
        {
            //Arrange
            var database = new Database();
            var userOne = new Person(1, "user");

            //Act
            database.Add(userOne);
            Person person = database.FindByUsername("user");

            //Assert
            Assert.NotNull(person);
        }
        [Test]
        public void SearchingForValidIDInTheDatabaseShouldReturnCorrectResult()
        {
            //Arrange
            var database = new Database();
            var userOne = new Person(1, "user");

            //Act
            database.Add(userOne);
            Person person = database.FindById(1);

            //Assert
            Assert.NotNull(person);
        }

        [Test]
        public void SearchingForUsersWithDifferentCasingShouldThrowException()
        {
            //Arrange
            var database = new Database();
            var userOne = new Person(1, "user");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(()=>database.FindByUsername("User"));
        }
        [Test]
        public void CountShouldReturnCorrectValue()
        {
            //Arrange
            var database = new Database();
            var userOne = new Person(1, "UserOne");

            //Act
            database.Add(userOne);

            //Assert
            Assert.AreEqual(database.Count, 1);
        }

        

        [Test]
        public void AddingRangeOfUsersWhenNotEnoughSpaceShouldThrowException()
        {
            //Arrange
            int size = 17;
            Person[] people = new Person[size];

            //Act
            for (int person = 0; person < size; person++)
            {
                var user = new Person(person, $"username-{person}");
                people[person] = user;
            }

            //Assert
            Assert.Throws<ArgumentException>(() => new Database(people));
        }

        [Test]
        public void AddingRangeOfUsersWhenEnoughSpaceShouldWorkAsExpected()
        {
            //Arrange
            int size = 5;
            Person[] people = new Person[size];

            //Act
            for (int person = 0; person < size; person++)
            {
                var user = new Person(person, $"username-{person}");
                people[person] = user;
            }

            var database = new Database(people);

            //Assert
            Assert.AreEqual(database.Count, size);
        }
    }
}