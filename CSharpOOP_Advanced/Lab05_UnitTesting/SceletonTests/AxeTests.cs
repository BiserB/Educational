using NUnit.Framework;
using System;

namespace SceletonTests
{
    
    public class AxeTests
    { 
        [Test]
        public void AxeLosesDurability()
        {
            Axe axe = new Axe(10, 10);

            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints.Equals(9), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void BrokenAxeThrowsException()
        {
            Axe axe = new Axe(10, 0);

            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => axe.Attack(dummy), 
                        Throws.InvalidOperationException
                              .With
                              .Message
                              .EqualTo("Axe is broken."));
        }
    }
}
