using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLoseDurabilityAfterAttack()
        {
            var axe = new Axe(1, 3);
            axe.Attack(new Dummy(4,2));
            Assert.That(2,Is.EqualTo(axe.DurabilityPoints),"Axe durability doesn't change after attack.");
        }
        [Test]
        public void AttackingWhenAxeIsBroken()
        {
            Axe axe=new Axe(1, 0);
            Dummy dummy=new Dummy(4,2);
            Assert.Throws<InvalidOperationException>(()=>axe.Attack(dummy),"Axe attacks even when broken.");
        }
    }
}