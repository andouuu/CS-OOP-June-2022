using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(initialData);
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        public void DatabaseCapacity_ShouldBeEqualToDataLength(int[] data)
        {
            //Arrange
            this.database = new Database.Database(data);

            //Act
            var expectedCapacity = data.Length;
            var actualCapacity = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenInitializedWithBiggerCollection()
        {
            //Arrange
            var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => new Database.Database(data));
        }

        [Test]
        public void Add_ShouldIncreaseCount_WhenAddedSuccessfully()
        {
            //Act
            this.database.Add(3);

            var expectedCount = 3;
            var actualCount = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Add_ShouldThrowException_WhenDatabaseFull()
        {
            //Act
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(17));
        }

        [Test]
        public void Remove_ShouldDecreaseCount_WhenSuccessfull()
        {
            //Act
            this.database.Remove();

            var expectedCount = 1;
            var actualCount = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Remove_ShouldThrowException_WhenDatabaseEmpty()
        {
            //Act
            this.database.Remove();
            this.database.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        [TestCase(new int[] { 1, 2, 2 })]
        [TestCase(new int[] { })]
        public void Fetch_ShouldReturnCopyOfData(int[] expectedData)
        {
            //Arrange
            this.database = new Database.Database(expectedData);

            //Act
            var actualData = this.database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}