using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LosingHealthWhenAttacked()
        {
            
            Dummy dummy = new Dummy(20, 5);
            dummy.TakeAttack(10);
            Assert.That(dummy.Health,Is.EqualTo(10),"Dummy doesn't lose health when attacked.");
        }

        [Test]
        public void ThrowingExceptionWhenDead()
        {
            Dummy dummy = new Dummy(0, 5);
            
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5),"Dummy doesn't throw an exception when dead.");
        }

        [Test]
        public void DeadDummyShouldGiveXP()
        {
            Dummy dummy = new Dummy(0, 5);
            Assert.That(dummy.GiveExperience(),Is.EqualTo(5),"Dummy doesn't give XP when dead.");
        }

        [Test]
        public void AliveDummyShouldntGiveXP()
        {
            Dummy dummy = new Dummy(5, 5);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive dummy shouldn't give XP.");
        }
    }
}